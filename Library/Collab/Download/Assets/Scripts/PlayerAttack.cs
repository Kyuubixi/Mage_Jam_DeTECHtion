using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

   /* private float timeBtwAttack;
    public float startTimeBtwAttack;
    private float timeBtwRangedAttack;
    public float startTimeBtwRangedAttack;
    private float animationAttackTimer;
    public float startAnimationAttackTimer;
    public Rigidbody2D rb2D;
    private CharacterController2D facing;

    private Animator animator;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    private int playerDamage;
    private Player playerScr;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public int bulletCountMax = 2;
    public int bulletCount;
    public bool emptyMag;

    private void Start()
    {
        playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerDamage;
        playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().animator;
        facing = FindObjectOfType<CharacterController2D>();
    }

    private void Update()
    {
        if (animator.GetBool("isWeaponOut") == false)
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    playerScr.invincibilityCounter = 0.5f;
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                    //animator.SetBool("isJumping", false);
                    if (enemiesToDamage != null)
                    {
                        for (int i = 0; i < enemiesToDamage.Length / 2; i++)
                        {
                            enemiesToDamage[i].GetComponent<PlatformAI>().takeDamage(playerDamage);
                        }
                        timeBtwAttack = startTimeBtwAttack;
                        //animator.SetTrigger("isAttacking");
                        rb2D.AddForce(new Vector2(300f * facing.isFacingRight, 150f));
                    }
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else if (animator.GetBool("isWeaponOut") == true)
        {
            if (bulletCount > 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                    animator.SetTrigger("isShooting");
                    rb2D.AddForce(new Vector2(-300f * facing.isFacingRight, 150f));
                    bulletCount--;
                }
            }
            if (bulletCount == 0)
            {
                emptyMag = true;
            }
            if (timeBtwRangedAttack <= 0 && emptyMag == true)
            {
                if(Input.GetButtonDown("Reload"))
                {
                    bulletCount = bulletCountMax;
                    timeBtwRangedAttack = startTimeBtwRangedAttack;
                }
            }
            else
            {
                timeBtwRangedAttack -= Time.deltaTime;
            }
            
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }*/
}