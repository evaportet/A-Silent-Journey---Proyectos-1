﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    public Transform Target;    
    public GameObject dialogBox;    
    public Text dialogText;    
    public string dialog;        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && playerInRange) 
        {
            if (dialogBox.activeInHierarchy) 
            {
                //if(Target.position.x == -13.37F)
                dialogBox.SetActive(false);
            }
            

            else 
            {
                //dialogBox.SetActive(true);
                
                    //dialogBox1.SetActive(false);
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                
                
                    
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            //dialogBox1.SetActive(false);
            dialogBox.SetActive(false);
            //dialogText.text = dialog;                    
            contextOff.Raise();

            //dialogBox.SetActive(false);
        }
    }


}