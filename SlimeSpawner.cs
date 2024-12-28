using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    float spawnrate; 
    float roundcooldown = 0 ;
    float xmax = 1.4f;
    float ymax = 0.5f;
    public GameObject slimes; 
    void Start()
    {
        
    }

    
    void Update()
    {
        if (roundcooldown > 2)
        {
            spawn();
            roundcooldown = 0;
        }


        roundcooldown += Time.deltaTime;


    }

    private void spawn()
    {
        if(slimes != null)
        Instantiate(slimes,new Vector2 (Random.Range(xmax*-1,xmax), Random.Range(ymax * -1, ymax)), Quaternion.identity);

    }
}
