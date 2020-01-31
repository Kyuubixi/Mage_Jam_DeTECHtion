﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    float vertical;
    float horizontal;
    public float healthBarLenght;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public int playerDamage = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        direction = Vector2.up;
        float vertical = Input.GetAxis("Vertical");
        healthBarLenght = Screen.width / 3;
    }

    void FixedUpdate()
    {
        Move();
        MoveInput();
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
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
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLenght, 20), currentHealth + "/" + maxHealth);
    }

    public void AddjustCurrentHealth(int ach)
    {
        currentHealth += ach;
        if (currentHealth < 0)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBarLenght = (Screen.width / 3) * (currentHealth / (float)maxHealth);
    }
}
