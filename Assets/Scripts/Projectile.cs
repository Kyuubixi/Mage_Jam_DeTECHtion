using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    
    private Player player;

    private Enemy enemy;
    public AudioSource music;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();
        music = FindObjectOfType<Enemy>().GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(player.playerDamage);
            music.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }
    }
}
