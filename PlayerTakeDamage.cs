using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    
    float damage = 5f;
    int cooldown = 1; 
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Debug.LogWarning("u died ");
                // animator.SetBool("IsDead", true);

            }
        }
        get { return health; }

    }
    public float health = 100f;
    public void TakeDamage(float damage)
    {
        Debug.Log("Taking Damage");
        Health -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")// && cooldown == 1)
        {
            TakeDamage(damage);
            //cooldown = 0;
           // Sleep();
        }
       

    }
    //private IEnumerator Sleep()
    //{
    //    yield return new WaitForSeconds(2f);
    //    cooldown = 1;

    //}

    private void OnTriggerExit2D(Collider2D collider)
    {

        cooldown = 1;

    }



}
