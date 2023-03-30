using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float health;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject deathScreen;
    bool dead = false;
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
        if(health <= 0 && !dead)
        {
            deathScreen.SetActive(true);
            healthBar.transform.parent.gameObject.SetActive(false);
            Destroy(GetComponent<Movement>());
            Destroy(GetComponent<Attacking>());
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            dead = true;
        }
    }
}
