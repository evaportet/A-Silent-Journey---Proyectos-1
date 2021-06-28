using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[3,3];
    public int coins;
    public Text CoinsTXT;
    public Inventory playerInventory;
    public FloatValue playerHealth;
    public VectorValue playerPosition;
    public SignalSender playerHealthSignal;
    void Start()
    {
        coins = playerInventory.coins;
        CoinsTXT.text = "Coins:" + coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        //Price
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 2;

        //Quantity
        //shopItems[3, 1] = 0;
        //shopItems[3, 2] = 0;
    }

    
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID] && playerHealth.RuntimeValue < playerHealth.initialValue)
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            if (playerInventory.coins - coins == 2)
            {
                playerHealth.RuntimeValue += 2;
            }
            else
            {
                playerHealth.RuntimeValue += 1;
            }
           playerInventory.coins = coins;
            CoinsTXT.text = "Coins:" + coins.ToString();
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID]++;
            //playerHealthSignal.Raise();
            
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID].ToString();


        }
    }
    public void StopBuying()
    {
        SceneManager.LoadScene("SampleScene");
        playerPosition.initialValue.x = -86.4F;
        playerPosition.initialValue.y = -5F;
        
    }
}
