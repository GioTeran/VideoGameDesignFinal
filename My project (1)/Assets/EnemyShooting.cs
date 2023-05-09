using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject character;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {   
       
        character = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(character != null)
        {
            float distance = Vector2.Distance(transform.position, character.transform.position);
            Debug.Log(distance);
            
            if(distance < 10)
            {
                timer += Time.deltaTime;
                if(timer > 2)
                {
                    timer = 0;
                    if(bulletPos == null)
                    {
                        return;
                    } else {
                        shoot();
                        FindObjectOfType<AudioManager>().Play("EnemyMagic");
                    }
                    
                }
            }
         }
       
       
        
        
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
