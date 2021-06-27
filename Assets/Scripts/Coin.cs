using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Powerup
{
    public Inventory playerInventory;
    public AudioSource coinUp;
    public GameObject coinUpObject;
    public Transform target;
    private void Start()
    {
        powerupSignal.Raise();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            if (playerInventory.numberOfStones >= 2)
            {
                Instantiate(coinUpObject);
                //coinUpObject.transform.position = target.position;
            }
            Destroy(this.gameObject);
            playerInventory.coins += 1;
            powerupSignal.Raise();
            

            //ScoreText.coinAmount += 1;

        }
        
    }

}
