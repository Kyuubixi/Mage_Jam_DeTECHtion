﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    float vertical;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction = Vector2.up;
        float vertical = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        MoveInput();
    }

    private void Move()
    { 
            transform.Translate(direction * speed * Time.deltaTime);
    }

    private void MoveInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }else if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        
    }
}
