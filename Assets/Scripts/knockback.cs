﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

       
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
                if (hit != null)
                {
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                    {
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                        other.GetComponent<Enemy>().Knock(hit, knockTime, damage);


                    }
                }
            }
        }
        else if (gameObject.CompareTag("enemy"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {

                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }


                }
                else if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    
                    
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                        other.GetComponent<Enemy>().Knock2(hit, knockTime);


                    
                }
            }
        }




        //if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        //{
        //    Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
        //    if (hit != null)
        //    {
        //        Vector2 difference = hit.transform.position - transform.position;
        //        difference = difference.normalized * thrust;
        //        hit.AddForce(difference, ForceMode2D.Impulse);
        //        if (other.gameObject.CompareTag("enemy") && other.isTrigger)
        //        {
        //            hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
        //            other.GetComponent<Enemy>().Knock(hit, knockTime, damage);


        //        }

        //        //hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
        //        if (other.gameObject.CompareTag("Player"))
        //        {
        //            if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
        //            {

        //                hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
        //                other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
        //            }


        //        }



        //    }
        //}
    }

    
}