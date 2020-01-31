using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public GameObject projectileEffect;
    public Transform shotPos;
    public Transform shotEffectPos;

    public Animator animator;
    public AudioSource audio;

    public float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("Weapon").GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0f, 0f, rotZ + offset);

        if(transform.localEulerAngles.z < 45 && transform.localEulerAngles.z > 0)
        {
            animator.SetFloat("Rotation", 8f);
        }
        else if (transform.localEulerAngles.z < 90 && transform.localEulerAngles.z > 45)
        {
            animator.SetFloat("Rotation", 7f);
        }
        else if (transform.localEulerAngles.z < 135 && transform.localEulerAngles.z > 90)
        {
            animator.SetFloat("Rotation", 6f);
        }
        else if (transform.localEulerAngles.z < 180 && transform.localEulerAngles.z > 135)
        {
            animator.SetFloat("Rotation", 5f);
        }
        else if (transform.localEulerAngles.z < 225 && transform.localEulerAngles.z > 180)
        {
            animator.SetFloat("Rotation", 4f);
        }
        else if (transform.localEulerAngles.z < 270 && transform.localEulerAngles.z > 225)
        {
            animator.SetFloat("Rotation", 3f);
        }
        else if (transform.localEulerAngles.z < 315 && transform.localEulerAngles.z > 270)
        {
            animator.SetFloat("Rotation", 2f);
        }
        else if (transform.localEulerAngles.z < 360 && transform.localEulerAngles.z > 315)
        {
            animator.SetFloat("Rotation", 1f);
        }



        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPos.position, transform.rotation);
                Instantiate(projectileEffect, shotEffectPos.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                audio.Play();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
