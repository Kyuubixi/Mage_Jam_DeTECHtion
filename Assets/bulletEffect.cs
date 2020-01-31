using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEffect : MonoBehaviour
{
    public float lifeTime;

    private void Update()
    {
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
