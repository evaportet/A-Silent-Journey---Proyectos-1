using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureChest4 : Interactable
{
    public item contents4;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox4;
    public Text dialogText4;
    private Animator anim;
    public Transform target;
    public ChestState4 myChest4;
    public FixCounter4 myCounter4;
    public DeathCounter myDeaths;

    void OnEnable()
    {
        if (myDeaths.counter != myCounter4.counter)
        {
            myCounter4.counter++;
            myChest4.RuntimeValue4 = myChest4.initialState4;
        }
        anim = GetComponent<Animator>();

        isOpen = myChest4.RuntimeValue4;

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


            if (!isOpen)
            {


                if (dialogBox4.activeInHierarchy)
                {

                    dialogBox4.SetActive(false);
                }
                else
                {

                    dialogBox4.SetActive(true);

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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon3") && target.position.x < 1.5F )
            {


                dialogBox4.SetActive(false);

                contextOff.Raise();

            }


        }

        myChest4.RuntimeValue4 = isOpen;
    }
    public void OpenChest()
    {
        isOpen = true;

        anim.SetBool("opened", true);
        playerInventory.AddItem(contents4);
        playerInventory.currentItem = contents4;

        raiseItem.Raise();

        dialogText4.text = contents4.itemDescription;

        playerInRange = false;


    }

    public void ChestAlreadyOpen()
    {

        dialogBox4.SetActive(false);


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

