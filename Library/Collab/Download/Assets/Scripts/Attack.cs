using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    /*public GameObject target;
    public float coolDown;
    public float attackTimer;
    public Enemy enemy;

    void Start()
    {
        coolDown = 2.0f;
        attackTimer = 0;
        //Enemy _enemyCurrentHealth=enemy.GetComponent<Enemy>();
        enemy = enemy.GetComponent<Enemy>();
    }

    void Update()
    {
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
                eh.AddjustcurrentHealth(-10);
            }
        }
    }*/
}
