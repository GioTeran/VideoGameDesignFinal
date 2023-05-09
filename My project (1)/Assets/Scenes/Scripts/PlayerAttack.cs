using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
   
    public int damage;
    public int staminaLoss= 10;
    public Animator playerAnim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0){
            // then you can attack
            if(Input.GetKey(KeyCode.Mouse0) && GetComponent<PlayerStamina>().currentStamina != 0){
                //camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("Attack");
                FindObjectOfType<PlayerStamina>().TakeStamina(staminaLoss);

                FindObjectOfType<AudioManager>().Play("PlayerAttackSword");

                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies );
              
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                
                    FindObjectOfType<AudioManager>().Play("SwordHit");
                }
            }
            
            
        }else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
