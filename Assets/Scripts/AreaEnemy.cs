using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Esqueleto
{
    public Collider2D boundary;
    public Collider2D boundary2;
    public Collider2D boundary3;
    public override void CheckDistance()
    {
        if (boundary.bounds.Contains(target.transform.position)|| boundary2.bounds.Contains(target.transform.position) || boundary3.bounds.Contains(target.transform.position))
        {
            //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("EsqueletoSize", true);
            }
        }
        else if (!boundary.bounds.Contains(target.transform.position) && !boundary2.bounds.Contains(target.transform.position) || !boundary3.bounds.Contains(target.transform.position))

        {
            anim.SetBool("EsqueletoSize", false);
        }
    }
}
