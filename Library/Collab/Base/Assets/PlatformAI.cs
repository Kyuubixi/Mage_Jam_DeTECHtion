using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAI : MonoBehaviour {

    public float speed;
    public float normalSpeed;
    private bool movingRight = true;

    private CameraShake shake;

    public Transform groundDetection;

    public int enemyHealth;

    private float dazedTime;
    public float startDazedTime;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    public void takeDamage(int damage)
    {
        dazedTime = startDazedTime;
        enemyHealth -= damage;
        shake.camShake();
        Debug.Log("Damage taken");
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);


        if (dazedTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }



        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
