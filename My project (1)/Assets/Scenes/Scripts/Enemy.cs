using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.AI;
using Pathfinding;


public class Enemy : MonoBehaviour
{

    //public AIPath aiPath;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform currentPoint;
    public int health;
    public float speed;
    private ICheck _groundCheck;
    
    
    private float dazedTime;
    public float startDazedTime;
    public GameObject Blood;
    public bool isInvulnerable = false;

    [SerializeField]
    private GameObject groundCheckObject;
   //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
        _groundCheck = groundCheckObject.GetComponent<ICheck>();
    }

    // Update is called once per frame
    void Update()

    {
        
       /* if(aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale= new Vector3(-1f,1f,1f);

        } else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        } */
      
        if(dazedTime <= 0) {
            speed = 5;
        }else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
      

        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage( int damage)
    {
        dazedTime =startDazedTime;
        Instantiate(Blood, transform.position, Quaternion.identity);
        if(isInvulnerable)
        {
            return;
        }
        


        health -= damage;
        Debug.Log("damage Taken");
        if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}
    }

    

     private bool IsGrounded()
    {
        return _groundCheck.Check();
    }

   
   
 
}




