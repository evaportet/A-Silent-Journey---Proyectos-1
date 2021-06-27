using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class FixCounter2 : ScriptableObject, ISerializationCallbackReceiver
{
    public int counter;
    public void OnAfterDeserialize()
    {
        counter = 1;
    }
    public void OnBeforeSerialize()
    {

    }
}
