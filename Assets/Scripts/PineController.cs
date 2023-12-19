using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineController : MonoBehaviour
{
    private const float VELOCITY_MAGTITUDE = 3.0f;
    private Rigidbody2D _rb2D;
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb2D.velocity = Vector2.left * VELOCITY_MAGTITUDE;
    }
}
