using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureChest3 : Interactable
{
    public item contents3;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox3;
    public Text dialogText3;
    private Animator anim;
    public Transform target;
    public ChestState3 myChest3;
    public FixCounter3 myCounter3;
    public DeathCounter myDeaths;

    void OnEnable()
    {
        if (myDeaths.counter != myCounter3.counter)
        {
            myCounter3.counter++;
            myChest3.RuntimeValue3 = myChest3.initialState3;
        }
        anim = GetComponent<Animator>();

        isOpen = myChest3.RuntimeValue3;

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


                if (dialogBox3.activeInHierarchy)
                {

                    dialogBox3.SetActive(false);
                }
                else
                {

                    dialogBox3.SetActive(true);

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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon2"))
            {


                dialogBox3.SetActive(false);

                contextOff.Raise();

            }


        }

        myChest3.RuntimeValue3 = isOpen;
    }
    public void OpenChest()
    {
        isOpen = true;

        anim.SetBool("opened", true);
        playerInventory.AddItem(contents3);
        playerInventory.currentItem = contents3;

        raiseItem.Raise();

        dialogText3.text = contents3.itemDescription;

        playerInRange = false;


    }

    public void ChestAlreadyOpen()
    {

        dialogBox3.SetActive(false);


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
