using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

       
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("enemy"))
                {
                    
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                }

                //hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                if (other.gameObject.CompareTag("Player"))
                {
                    
                    other.GetComponent<PlayerMovement>().Knock( knockTime);
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                }
                  
               
                
            }
        }
    }

    
}