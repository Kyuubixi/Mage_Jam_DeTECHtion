using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemyMaxHealth=100;
    public static int enemyCurrentHealth=100;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    public void AddjustCurrentHealth(int ach)
    {
        enemyCurrentHealth += ach;
        if (enemyCurrentHealth < 0)
        {
            enemyCurrentHealth = enemyMaxHealth;
        }
        if (enemyCurrentHealth > enemyMaxHealth)
        {
            enemyCurrentHealth = enemyMaxHealth;
        }
    }

}
