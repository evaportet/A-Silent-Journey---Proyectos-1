using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class ChestState4 : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState4;

    //[HideInInspector]
    public bool RuntimeValue4;

    public void OnAfterDeserialize()
    {
        RuntimeValue4 = initialState4;
    }
    public void OnBeforeSerialize()
    {

    }
}
