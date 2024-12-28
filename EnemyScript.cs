using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Animator animator;
    public Transform player;
    Vector2 movementinput;
    SpriteRenderer spriterenderer;
    float speed = 0.3f;
  
    

    public float Health
    {
        set
        {
            health = value;
            if(health <=0)
            {
                animator.SetBool("IsDead",true);
                
            }
        }
        get { return health; }

    }
    public float health = 1; 
 public void TakeDamage(float damage)
    {
        Health -= damage;
    }
    void Start()
    {
        
        animator = GetComponent<Animator> ();
        spriterenderer = GetComponent<SpriteRenderer>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        animator.SetBool("IsMoving", true);
       
        

    }
    void   Update()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
       

        
    }
    public void Lost()
    {
        Destroy(gameObject);
    }
  
}
