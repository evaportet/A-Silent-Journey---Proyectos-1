using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
[System.Serializable]
public class KeyDoorState : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState;
    public bool RuntimeValue;
    //[HideInInspector]


    public void OnAfterDeserialize()
    {
        RuntimeValue = initialState;
    }
    public void OnBeforeSerialize()
    {

    }
    
}
