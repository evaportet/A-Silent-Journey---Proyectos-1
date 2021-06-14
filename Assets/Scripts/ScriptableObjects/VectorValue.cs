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
        initialValue.x = 0F;
        initialValue.y = -3F;
    }
    public void OnBeforeSerialize() {
        
    
    }
}

