using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
[System.Serializable]
public class ChestState1 : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState;

    //[HideInInspector]
    public bool RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialState;
    }
    public void OnBeforeSerialize()
    {
        
    }
    
}
