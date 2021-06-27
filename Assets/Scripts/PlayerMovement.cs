using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public PlayerState currentState;
    public float speed; //velocidad del jugador
    private Rigidbody2D myRigidbody; //el rigidbody del jugador
    private Vector3 change; //vector
    private Animator animator; //animator
    public FloatValue currentHealth;
    public SignalSender playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public AudioSource pasos;
    public AudioSource pasosArena;
    public AudioSource atack;
    
    
    //public FloatValue initialHealth;

    //muerte
    public UnityEngine.UI.Image Oscuro;
    float valorAlfaDeseado;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
        //range = GameObject.Find("playerInRange").GetComponent<TreasureChest2>().playerInRange;
        //glitchSolved = false;
        //currentHealth = initialHealth;
    }

    // Update is called once per frame
   
    void Update()
    {
        // Is the player in an inteacticon
        if(currentState == PlayerState.interact)
        {
            
            return;
        }        
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack")&& currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (playerInventory.numberOfStones >= 2)
            {
                atack.Play();
            }            
            StartCoroutine(AttackCo());
            
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
            
            
        }
        
               

        //manejar tela negra
        float valorAlfa = Mathf.Lerp(Oscuro.color.a, valorAlfaDeseado, 0.02f);
        Oscuro.color = new Color(0, 0, 0, valorAlfa);

        //reiniciar escena (muerte)
        if (valorAlfa > 0.9)
        {
            SceneManager.LoadScene("Scenes/House");
        }
       
    }
        
    private IEnumerator AttackCo()
    {
        animator.SetBool("pattacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("pattacking", false);
        yield return new WaitForSeconds(.6f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
      
    }
    public void RaiseItem()
    {
        //if (playerInventory.currentItem != null)
        //{
        
        if (currentState != PlayerState.interact )
        {

                animator.SetBool("Receive item", true);
                currentState = PlayerState.interact;
                
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;

        }
        
        else 
        {
            animator.SetBool("Receive item", false);
            currentState = PlayerState.idle;
            receivedItemSprite.sprite = null;
            playerInventory.currentItem = null;
        }
        //}

    }
        void UpdateAnimationAndMove ()
    { 
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            if (playerInventory.numberOfStones >= 2) //&& !pasos.isPlaying) target.position.x > -19.6F && target.position.y > 7.8F && target.position.y < 35.6F)
            {
                //if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SampleScene"))
                //{
                //    pasosArena.Stop();
                //}
                if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && transform.position.x > -19.6F && transform.position.y > 7.8F && transform.position.y < 35.6F && !pasosArena.isPlaying)
                {
                    
                    pasosArena.Play();                    
                    pasos.Stop();
                    
                }
                else if (!pasos.isPlaying )
                {
                    if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && (transform.position.x < -19.6F || transform.position.y < 7.8F || transform.position.y > 35.6F))
                    {
                        pasosArena.Stop();
                        pasos.Play();
                    }
                    else if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SampleScene"))
                    {
                        pasos.Play();
                    }
                    
                }
                                
            }
        }
        else
        {
            animator.SetBool("moving", false);
            if (pasos.isPlaying)
            {
                pasos.Stop();
            }
            if (pasosArena.isPlaying)
            {
                pasosArena.Stop();
            }
        }
    }

    void MoveCharacter() 
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime);        

    }
    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        

        if (currentHealth.RuntimeValue > 0)
        {
           
            StartCoroutine(KnockCo(knockTime));
            

        }
        else
        {
            //this.gameObject.SetActive(false);

            //animacion muerte
            //currentState = PlayerState.idle;
           

            animator.SetTrigger("death");            
            valorAlfaDeseado = 1;
            currentHealth.RuntimeValue = currentHealth.initialValue;
            startingPosition.initialValue.x = 0F;
            startingPosition.initialValue.y = -3F;
            

        }
        playerHealthSignal.Raise();
    }
    private IEnumerator KnockCo( float knockTime)
    {

        if (myRigidbody != null)
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            

            //myRigidbody.velocity = Vector2.zero;

        }
        
    }

    public void FadeOut() {
        valorAlfaDeseado = 1;
    }
    
}
