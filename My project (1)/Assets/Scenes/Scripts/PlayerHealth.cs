using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject HealthBoost;
    public int HealthBonus = 15;
    public GameObject character;
    public int sceneBuildIndex;
    
    // Start is called before the first frame update

    public healthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       // take damage when attacked
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        FindObjectOfType<AudioManager>().Play("PlayerDamaged");

        if(currentHealth <= 0){
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            

        }
    }
    public void AddHealth(int healthAdded)
    {
        if(currentHealth < maxHealth){

        
        currentHealth = currentHealth + HealthBonus;
        healthBar.SetHealth(currentHealth);
        }
    }
}
