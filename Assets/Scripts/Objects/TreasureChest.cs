using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureChest : Interactable
{
    public item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    public Transform target;
    public ChestState1 myChest1;
    public FixCounter myCounter;
    public DeathCounter myDeaths;

    //public bool nextIsOpen = false;

    // Start is called before the first frame update
    //void OnDisable()
    //{
    //    //PlayerPrefs.SetInt("openari", BoolToInt( isOpen));

    //}


    void OnEnable()
    {
        if(myDeaths.counter != myCounter.counter)
        {
            myCounter.counter++;
            myChest1.RuntimeValue = myChest1.initialState;
        }

        anim = GetComponent<Animator>();
        isOpen = myChest1.RuntimeValue;

        if (isOpen)
        {
            anim.SetBool("directOpen", true);
        }
        else
        {
            anim.SetBool("directOpen", false);
        }


    }
    private void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.B) && playerInRange)
        {
            

            if (!isOpen)
            {
               

                if (dialogBox.activeInHierarchy)
                {
                    //if(Target.position.x == -13.37F)
                    dialogBox.SetActive(false);
                }
                else
                {
                    
                    // Dialog window on
                    dialogBox.SetActive(true);
                    

                }
                // raise the context clue
                
                OpenChest();          

            }
            else
            {
                //spriteRenderer.sprite = newSprite;
                ChestAlreadyOpen();
                
            }
            

        }
        else if (!playerInRange)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && transform.position.x == -91.49F && target.position.x <-90.42F && target.position.y > 21.8F)
            {
                contextOff.Raise();
            }   
            

            if (dialogBox.activeInHierarchy)
            {

                //if(Target.position.x == -13.37F)
                dialogBox.SetActive(false);
            }
            
            
        }
        myChest1.RuntimeValue = isOpen;
    }
    public void OpenChest()
    {
        isOpen = true;
        // set chest to open       
        anim.SetBool("opened", true);
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the signal to the player to animate
        raiseItem.Raise();

        //contextOff.Raise();

        
        
        // dialog text = contents text
       
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        
        playerInRange = false;
        






    }

    public void ChestAlreadyOpen()
    {


        dialogBox.SetActive(false);


        playerInRange = false;
        raiseItem.Raise();
        
        //raise the signal to the player to stop animating

        //Dialog off
        
        





    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")  && !isOpen)
        {
            playerInRange = true;
            contextOn.Raise();

        }
        if(other.CompareTag("Player") && isOpen)
        {
            playerInRange = false;
        }



    }
    //public void ChestStateOnScene()
    //{
    //    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
    //    {

    //    }
    //}
        

}
