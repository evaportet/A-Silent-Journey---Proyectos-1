﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChestState2 : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialState2;

    //[HideInInspector]
    public bool RuntimeValue2;

    public void OnAfterDeserialize()
    {
        RuntimeValue2 = initialState2;
    }
    public void OnBeforeSerialize()
    {

    }
}