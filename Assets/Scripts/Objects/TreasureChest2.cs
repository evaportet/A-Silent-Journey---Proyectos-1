using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureChest2 : Interactable
{
    public item contents2;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox2;
    public Text dialogText2;
    private Animator anim;
    public Transform target;
    public ChestState2 myChest2;
    public FixCounter2 myCounter2;
    public DeathCounter myDeaths;

    void OnEnable()
    {
        if (myDeaths.counter != myCounter2.counter)
        {
            myCounter2.counter++;
            myChest2.RuntimeValue2 = myChest2.initialState2;
        }

        anim = GetComponent<Animator>();

        isOpen = myChest2.RuntimeValue2;

        if (isOpen)
        {
            anim.SetBool("directOpen", true);
        }
        else
        {
            anim.SetBool("directOpen", false);
        }

        
    }    

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.B) && playerInRange)
        {


            if (!isOpen )
            {


                if (dialogBox2.activeInHierarchy)
                {
                    
                    dialogBox2.SetActive(false);
                }
                else
                {

                    dialogBox2.SetActive(true);

                }

                OpenChest();

            }
            
            else
            {               
                    ChestAlreadyOpen();
                         
            }
        }
        
        else if (!playerInRange)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon1"))
            {


                dialogBox2.SetActive(false);
                
                contextOff.Raise();

            }
                        

        }
        
        myChest2.RuntimeValue2 = isOpen;
    }
    public void OpenChest()
    {
        isOpen = true;
              
        anim.SetBool("opened", true);
        playerInventory.AddItem(contents2);
        playerInventory.currentItem = contents2;
        
        raiseItem.Raise();

        dialogText2.text = contents2.itemDescription;       

        playerInRange = false;


    }

    public void ChestAlreadyOpen()
    {

        dialogBox2.SetActive(false);


        playerInRange = false;
        raiseItem.Raise();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            playerInRange = true;
            contextOn.Raise();

        }
        if (other.CompareTag("Player") && isOpen)
        {
            playerInRange = false;
        }



    }    

}
