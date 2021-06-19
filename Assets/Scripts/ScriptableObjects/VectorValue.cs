using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;

    [HideInInspector]
    public double RuntimeValue;
    public void OnAfterDeserialize()
    {
        initialValue.x = 0F;//-91.5F;
        initialValue.y = -3F;//22F;
    }
    public void OnBeforeSerialize() {
        
    
    }
}

