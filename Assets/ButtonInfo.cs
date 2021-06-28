using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public Text PriceTxt;
    //public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, itemID].ToString();
        //QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, itemID].ToString();
    }
}
