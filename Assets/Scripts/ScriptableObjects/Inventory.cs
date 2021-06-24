using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public item currentItem;
    public List<item> items = new List<item>();
    public int numberOfKeys;
    public int numberOfStones;
    public int coins;

    //public void OnEnable()
    //{
    //    items.Clear();
    //    numberOfKeys = 0;
    //    numberOfStones = 0;
    //}
    public void OnAfterDeserialize()
    {
        numberOfKeys = 0;
        numberOfStones = 0;
        coins = 0;
        items.Clear();
    }
    public void OnBeforeSerialize()
    {

    }
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
