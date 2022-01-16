using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousMove : MonoBehaviour
{
    public float hor_speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(hor_speed, rb.velocity.y);
    }
}
