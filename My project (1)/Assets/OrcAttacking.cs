using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttacking : MonoBehaviour
{
    public GameObject character;

    // Update is called once per frame

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
         
         
        
    }
}
