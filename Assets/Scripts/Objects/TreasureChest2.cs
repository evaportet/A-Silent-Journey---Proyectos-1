//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class TreasureChest2 : Interactable
//{
//    public item contents;
//    public Inventory playerInventory;
//    public bool isOpen;
//    public SignalSender raiseItem;
//    public GameObject dialogBox;
//    public Text dialogText;
//    private Animator anim;
//    public Transform target;
//    public ChestState2 myChest2;

//    //public bool nextIsOpen = false;

//    // Start is called before the first frame update
//    //void OnDisable()
//    //{
//    //    //PlayerPrefs.SetInt("openari", BoolToInt( isOpen));

//    //}


//    void OnEnable()
//    {

//        anim = GetComponent<Animator>();

//        isOpen = myChest2.initialState2;

//        if (isOpen)
//        {
//            anim.SetBool("directOpen", true);
//        }
//        else
//        {
//            anim.SetBool("directOpen", false);
//        }


//    }
//    private void Start()
//    {




//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (Input.GetKeyDown(KeyCode.B) && playerInRange)
//        {


//            if (!isOpen)
//            {


//                if (dialogBox.activeInHierarchy)
//                {
//                    //if(Target.position.x == -13.37F)
//                    dialogBox.SetActive(false);
//                }
//                else
//                {

//                    // Dialog window on
//                    dialogBox.SetActive(true);


//                }
//                // raise the context clue

//                OpenChest();

//            }
//            else
//            {
//                //spriteRenderer.sprite = newSprite;
//                ChestAlreadyOpen();

//            }


//        }
//        else if (!playerInRange)
//        {
//            if (transform.position.x == 0F && target.position.x > -1.4F && target.position.x < 1.05F && target.position.y > 2.3F)
//            {
//                contextOff.Raise();
//            }


//            if (dialogBox.activeInHierarchy)
//            {
//                //if(Target.position.x == -13.37F)
//                dialogBox.SetActive(false);
//            }


//        }
//        myChest2.initialState2 = isOpen;
//    }
//    public void OpenChest()
//    {
//        isOpen = true;
//        // set chest to open       
//        anim.SetBool("opened", true);
//        playerInventory.AddItem(contents);
//        playerInventory.currentItem = contents;
//        //Raise the signal to the player to animate
//        raiseItem.Raise();

//        //contextOff.Raise();



//        // dialog text = contents text

//        dialogText.text = contents.itemDescription;
//        // add contents to the inventory

//        playerInRange = false;






//    }

//    public void ChestAlreadyOpen()
//    {


//        dialogBox.SetActive(false);


//        playerInRange = false;
//        raiseItem.Raise();

//        //raise the signal to the player to stop animating

//        //Dialog off







//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player") && !isOpen)
//        {
//            playerInRange = true;
//            contextOn.Raise();

//        }
//        if (other.CompareTag("Player") && isOpen)
//        {
//            playerInRange = false;
//        }



//    }
//    //public void ChestStateOnScene()
//    //{
//    //    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
//    //    {

//    //    }
//    //}
//    int BoolToInt(bool val)
//    {
//        if (val)
//            return 1;
//        else
//            return 0;
//    }

//    bool IntToBool(int val)
//    {
//        if (val != 0)
//            return true;
//        else
//            return false;
//    }

//    //private voidOnTriggerExit2D(Collider2D other)
//    //{
//    //    playerInRange = false;
//    //    //contextOff.Raise();

//    //    //if (other.CompareTag("Player")  && isOpen)
//    //    //{
//    //    //    playerInRange = false;
//    //    //    //dialogBox1.SetActive(false);

//    //    //    //dialogText.text = dialog;                    
//    //    //    contextOff.Raise();

//    //    //    //dialogBox.SetActive(false);
//    //    //}
//    //}

//}
