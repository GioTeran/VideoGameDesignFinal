using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDamage : MonoBehaviour
{
    public GameObject character;
    public GameObject Orc;
    public int sceneBuildIndex;

    

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
         if(other.gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        

    }
}
