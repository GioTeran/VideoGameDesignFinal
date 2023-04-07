using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Enemys{
public class Enemy : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public int health;
    public float speed;
    private ICheck _groundCheck;
    public GameObject bloodEffect;
    private float dazedTime;
    public float startDazedTime;

    [SerializeField]
    private GameObject groundCheckObject;
   //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint=  pointB.transform;
        anim.SetBool("IsWalking", true);
        _groundCheck = groundCheckObject.GetComponent<ICheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0) {
            speed = 5;
        }else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
           rb.velocity = new Vector2(speed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(-speed, 0 );
        }

        if(Vector2.Distance(transform.position , currentPoint.position) < .5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
        if(Vector2.Distance(transform.position , currentPoint.position) < .5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }

        if(health <= 0){
            Destroy(gameObject);
        }
    }
    public void TakeDamage( int damage){
        dazedTime =startDazedTime;
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken");
    }

     private bool IsGrounded()
    {
        return _groundCheck.Check();
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *=-1;
        transform.localScale = localScale;
    }
   private void OnDrawGizmos()
   {
    Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
    Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
   }
}

}

