using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletMoveSpeed = 3f;

    public Rigidbody2D rb;

    public float startDestroyTimer = 3f;
    private float destroyTimer = 3f;

    private Player player;
    private Enemy enemy;
    Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Player>();
        moveDir = (player.transform.position - transform.position).normalized * bulletMoveSpeed;
        rb.velocity = new Vector3(moveDir.x, moveDir.y);
        Destroy(gameObject, 3f);
        enemy = FindObjectOfType<Enemy>().GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.DealDamage();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }
    }
}
