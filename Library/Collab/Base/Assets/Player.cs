using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterController2D controller;
    public _GameManager gameManager;

    private CameraShake shake;

    private CharacterController2D facing;

    public Rigidbody2D rb2D;

    public float runSpeed = 30f;
    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;

    public int health;
    public int playerDamage;

    private void Start()
    {
        gameManager = FindObjectOfType<_GameManager>();
        facing = FindObjectOfType<CharacterController2D>();
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update ()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(animator.GetBool("isWeaponOut") == true)
        {
            runSpeed = 10f;
        }
        else
        {
            runSpeed = 30f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            facing.jumpTimer = 0.4f;
        }

        if (Input.GetButtonDown("WeaponOut"))
        {
            animator.SetBool("isWeaponOut", true);
        }
        else if (Input.GetButtonDown("WeaponHide"))
        {
            animator.SetBool("isWeaponOut", false);
        }


        invincibilityCounter -= Time.deltaTime;
    }

    public void onLanding ()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        if(health <= 0)
        {
            gameManager.PlayerRespawn();
            health = 3;
        }
    }

    public float invincibilityLength;
    public float invincibilityCounter;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (invincibilityCounter <= 0)
            {
                health--;
                Debug.Log(health);
                invincibilityCounter = invincibilityLength;
                rb2D.AddForce(new Vector2(-300f*facing.isFacingRight, 200f));
                shake.camShake();
            }
        }
    }
}