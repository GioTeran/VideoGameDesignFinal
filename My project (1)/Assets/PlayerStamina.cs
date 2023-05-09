using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{

    
    public int maxStamina = 100;
    public int currentStamina;
    private float timer;
    public int StaminaBoost;
    // Start is called before the first frame update
    public StaminaBar staminaBar;
    
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(currentStamina < maxStamina)
        {
            if(timer > 2)
            {
                AddStamina(15);
                timer = 0;
            }
        }
    }

    public void TakeStamina(int staminaLoss)
    {
        
        
        currentStamina -= staminaLoss;
        staminaBar.SetStamina(currentStamina);
        

        
    }

    public void AddStamina(int staminaAdded)
    {
        
        currentStamina = currentStamina + StaminaBoost;
        staminaBar.SetStamina(currentStamina);
    
        
    }
}
