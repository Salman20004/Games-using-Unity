using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckScript : MonoBehaviour
{


    public float damage = 3;
 
    public Collider2D _attackCollider;
    public GameObject player;

public void AttackRight()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y) + new Vector2(0.128f, -0.0979f);
        _attackCollider.enabled = true; 
        print("Attack right");
    }
    public void AttackLeft()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y) + new Vector2(-0.128f, -0.0979f);

        _attackCollider.enabled = true;
       
        print("Attack left");


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
                enemy.Health -= damage;
        }
    }
    public void StopAttack()
    {
        _attackCollider.enabled = false;
    }
}
