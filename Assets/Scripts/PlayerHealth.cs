using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float health;
    [SerializeField] Image healthBar;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("death");
        }
    }
}
