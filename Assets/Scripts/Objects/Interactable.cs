using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public SignalSender contextOn;
    public SignalSender contextOff;
    public bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            contextOn.Raise();

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
