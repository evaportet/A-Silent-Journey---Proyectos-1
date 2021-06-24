using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Powerup
{
    public Inventory playerInventory;
    private void Start()
    {
        powerupSignal.Raise();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            Destroy(this.gameObject);
            playerInventory.coins += 1;
            powerupSignal.Raise();
            //ScoreText.coinAmount += 1;
           
        }
        
    }

}
