using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class DeathCounter : ScriptableObject, ISerializationCallbackReceiver
{
    public int counter;
    public void OnAfterDeserialize()
    {
        counter = 0;
    }
    public void OnBeforeSerialize()
    {

    }
}
