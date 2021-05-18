using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public PlayerState currentState;
    public float speed; //velocidad del jugador
    private Rigidbody2D myRigidbody; //el rigidbody del jugador
    private Vector3 change; //vector
    private Animator animator; //animator

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack")&& currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        
    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("pattacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("pattacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove ()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() 
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime);
    }
}
