using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10;
    [SerializeField] GameObject smokeEffect;
    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            smokeEffect.SetActive(true);
            smokeEffect.transform.parent = null;
            Destroy(smokeEffect, 3);
            Destroy(this.gameObject);
        }
    }
}
