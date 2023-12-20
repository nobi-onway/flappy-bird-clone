using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private const float VELOCITY_MAGNITUDE = 4.0f;
    private const float GRAVITY_SCALE = 1.0f;
    private Vector2 INITIAL_POSITION = new Vector2(-1.5f, -1);

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Animator _animator;

    public delegate void BirdEventHandler();

    public event BirdEventHandler OnScore;
    public event BirdEventHandler OnDead;

    private bool canFly;

    private void OnEnable()
    {
        OnDead += () => Dead();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    public void Init()
    {
        _rb2D.gravityScale = GRAVITY_SCALE;
        canFly = true;
    }

    public void ResetState()
    {
        _rb2D.gravityScale = 0;
        _rb2D.constraints = RigidbodyConstraints2D.None;
        _animator.enabled = true;
        canFly = false;
        transform.position = INITIAL_POSITION;
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFly) MoveUp();
    }

    private void MoveUp()
    {
        _rb2D.velocity = Vector2.up * VELOCITY_MAGNITUDE;
    }

    private void Dead()
    {
        _rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        _animator.enabled = false;
        canFly = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score")) OnScore?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dead")) OnDead?.Invoke();
    }

    private void UnsubscribeAllBirdEventHandler(BirdEventHandler handler)
    {
        Delegate[] delegates = handler.GetInvocationList();

        foreach(Delegate d in delegates)
        {
            OnDead -= d as BirdEventHandler;
        }
    }

    private void UnsubscribeEvents()
    {
        UnsubscribeAllBirdEventHandler(OnDead);
        UnsubscribeAllBirdEventHandler(OnScore);
    }
}
