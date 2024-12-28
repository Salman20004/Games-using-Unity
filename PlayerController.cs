using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collsionOffset = 0.05f;

    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Vector2 movementinput;
    Rigidbody2D rb;
    Animator animator;
    public AttckScript swordattack; 
    SpriteRenderer spriterenderer;
    
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
   

    private void FixedUpdate() //if movement inout is not  0 , try to move 
    {
        
            

        if (movementinput != Vector2.zero)
        {
          bool success  = TryMove(movementinput);
            if ( !success)
            {
             success =  TryMove(new Vector2(movementinput.x, 0));
               
            }
            if (!success)
            {
                success = TryMove(new Vector2(0, movementinput.y));
            }
            animator.SetBool("IsMoving", success);
            if (movementinput.y > 0)
            {
                animator.SetBool("LookingUp", true);
            }
               
            else if (movementinput.y < 0)
            {
                animator.SetBool("LookingUp", false);
                
            }

        }else
        {
            animator.SetBool("LookingUp", false);
            animator.SetBool("IsMoving", false); }
        if (movementinput.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else if (movementinput.x > 0)
        {
            spriterenderer.flipX = false;
        


        }

    }
    private bool TryMove(Vector2 direction)
        
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collsionOffset); //if count is 0 then we move
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            
            return false;
        }
        
        return false;
    }

    void OnMove(InputValue MovementValue )
    {
        movementinput = MovementValue.Get<Vector2>();
    }
    void OnFire()
    {
        animator.SetTrigger("SwordAttack");
    }
  
    private void SwordAttack()
    {
        if (spriterenderer.flipX == true) swordattack.AttackLeft();
        else swordattack.AttackRight();
    }
   
    public void endAttack()
    {
    swordattack.StopAttack();
    }

}
