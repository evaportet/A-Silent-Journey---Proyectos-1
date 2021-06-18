using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class item : ScriptableObject
{
    public Sprite itemSprite;
    public string itemDescription;
    public bool isKey;
    public bool isStone;
}
