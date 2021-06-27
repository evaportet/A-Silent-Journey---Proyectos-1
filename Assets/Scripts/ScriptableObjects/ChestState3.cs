using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
[System.Serializable]
public class ChestState3 : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState3;

    //[HideInInspector]
    public bool RuntimeValue3;

    public void OnAfterDeserialize()
    {
        RuntimeValue3 = initialState3;
    }
    public void OnBeforeSerialize()
    {

    }
   
}
