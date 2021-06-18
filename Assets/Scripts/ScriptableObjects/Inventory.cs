using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public item currentItem;
    public List<item> items = new List<item>();
    public int numberOfKeys;
    public int numberOfStones;

    //public void OnEnable()
    //{
    //    items.Clear();
    //    numberOfKeys = 0;
    //    numberOfStones = 0;
    //}
    public void AddItem(item itemToAdd)
    {
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        else if(itemToAdd.isStone){
            numberOfStones++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
