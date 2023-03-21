using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10;
    public void Damage(float damage)
    {
        health -= damage;
    }
}
