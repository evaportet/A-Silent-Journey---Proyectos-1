using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAtack;
    public float moveSpeed;
    public GameObject deathEffect;
    public GameObject coin;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {

        health -= damage;
        if (health <= 0)
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if( deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);            
            
            
            coin.transform.position = transform.position;
            coin.SetActive(true);


        }


    }
       

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        TakeDamage(damage);
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        
    }
    public void Knock2(Rigidbody2D myRigidbody, float knockTime)
    {
        
        StartCoroutine(KnockCo(myRigidbody, knockTime));

    }


    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {

        if (myRigidbody != null )
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;

        }

    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(health<=0 && other.isTrigger)
    //    {

    //    }
    //}
}
