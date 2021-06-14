using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    
    private void Start()
    {
        anim = GetComponent<Animator>();
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
                
                ChestAlreadyOpen();
                
            }
            

        }
        else if (!playerInRange)
        {
            contextOff.Raise();

            if (dialogBox.activeInHierarchy)
            {
                //if(Target.position.x == -13.37F)
                dialogBox.SetActive(false);
            }
            
            
        }
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
    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        contextOff.Raise();
        
        //if (other.CompareTag("Player")  && isOpen)
        //{
        //    playerInRange = false;
        //    //dialogBox1.SetActive(false);

        //    //dialogText.text = dialog;                    
        //    contextOff.Raise();

        //    //dialogBox.SetActive(false);
        //}
    }
   
}
