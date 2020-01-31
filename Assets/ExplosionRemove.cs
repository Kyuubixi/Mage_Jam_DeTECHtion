using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRemove : MonoBehaviour
{
    public float startRemoveTimer = 0.5f;

    private void Update()
    {
        if(startRemoveTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            startRemoveTimer -= Time.deltaTime;
        }
    }
}
