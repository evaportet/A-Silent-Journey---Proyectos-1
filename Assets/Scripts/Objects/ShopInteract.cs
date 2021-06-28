using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInteract : Interactable
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && playerInRange)
        {

            SceneManager.LoadScene("Shop");

           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            //dialogBox1.SetActive(false);
            
            //dialogText.text = dialog;                    
            contextOff.Raise();

            //dialogBox.SetActive(false);
        }
    }

}
