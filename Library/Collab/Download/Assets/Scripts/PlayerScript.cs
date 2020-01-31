using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    float vertical;
    float horizontal;
    public float healthBarLenght;
    public float maxHealth=100;
    public float currentHealth = 100;
    public GameObject target;
    public float coolDown;
    public float attackTimer;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction = Vector2.up;
        float vertical = Input.GetAxisRaw("Vertical");
        healthBarLenght = Screen.width / 3;
        coolDown = 2.0f;
        attackTimer = 0;
        //Enemy _enemyCurrentHealth=enemy.GetComponent<Enemy>();
        enemy = enemy.GetComponent<Enemy>();
    }
    private void Update()
    {
        AddjustCurrentHealth(0);
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackTimer == 0)
            {
                Attacking();
                attackTimer = coolDown;
            }
        }
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
    private void Attacking()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        Vector2 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector2.Dot(dir, transform.forward);
        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                Enemy eh = (Enemy)target.GetComponent("EnemyHealth");
                eh.AddjustCurrentHealth(-10);
            }
        }
    }
}
