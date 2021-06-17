using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChestState1 : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState;

    [HideInInspector]
    public double RuntimeValue;

    public void OnEnable()
    {
        initialState = false;
    }
    public void OnAfterDeserialize()
    {
        
    }
    public void OnBeforeSerialize()
    {


    }
}
