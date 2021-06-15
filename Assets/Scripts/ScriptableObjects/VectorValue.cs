﻿using System.Collections;
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
        initialValue.x = -91.44F;
        initialValue.y = 22.66F;
    }
    public void OnBeforeSerialize() {
        
    
    }
}

