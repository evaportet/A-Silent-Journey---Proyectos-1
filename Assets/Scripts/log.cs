﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float atackRadius;
    public Transform homePosition;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > atackRadius)
        {
            ChangeState(EnemyState.walk);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
               // transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                anim.SetBool("wakeUp", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
               
                
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius && Vector3.Distance(target.position, transform.position) > atackRadius)

        {
            ChangeState(EnemyState.stagger);
            anim.SetBool("wakeUp", false);
        }
    }
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
