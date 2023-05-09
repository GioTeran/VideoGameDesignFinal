using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    PlayerHealth playerHealth;
    healthBar HealthBar;

    public int HealthBonus = 15;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            col.gameObject.GetComponent<PlayerHealth>().AddHealth(15);
            Destroy(gameObject);
        }
    }
}
