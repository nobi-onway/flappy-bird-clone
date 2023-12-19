using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private const float VELOCITY_MAGNITUDE = 5.0f;
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) MoveUp();
    }

    private void MoveUp()
    {
        _rb2D.velocity = Vector2.up * VELOCITY_MAGNITUDE;
    }
}
