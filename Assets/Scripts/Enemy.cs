using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth = 100;
    public int enemyDamage = 5;

    public float speed;

    private CameraShake camAnim;

    private Rigidbody rb;

    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject shot;
    public Transform player;
    private Player playerScr;
    public AudioSource robotHitSource;
    public AudioClip robotHitClip;
    public AudioClip hit1Clip;
    public AudioSource hit1Source;
    public AudioClip hit2Clip;
    public AudioSource hit2Source;
    private int rand;
    public GameObject explosionEffect;

    public AudioSource audio;

    private void Start()
    {
        camAnim = FindObjectOfType<CameraShake>();
        rb = GetComponent<Rigidbody>();
        playerScr = FindObjectOfType<Player>().GetComponent<Player>();
        robotHitSource.clip = robotHitClip;
    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) < nearDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
            {
                transform.position = this.transform.position;
            }
            if (Vector2.Distance(transform.position, player.position) > 10f)
            {
                player = null;
            }
            
            if (timeBtwShots <= 0)
            {
                Instantiate(shot, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }



    public void DealDamage()
    {
        playerScr.currentHealth -= enemyDamage;
        rand = Random.Range(0, 100);
        if (rand % 2 == 0)
        {
            hit1Source.clip = hit1Clip;
        }
        else if (rand % 2 == 1)
        {
            hit1Source.clip = hit2Clip;
        }
        hit1Source.Play();
        Debug.Log(rand);
    }

    public void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        
        if (enemyCurrentHealth <= 0)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            camAnim.camShake();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = FindObjectOfType<Player>().transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audio.Play();
    }
}
