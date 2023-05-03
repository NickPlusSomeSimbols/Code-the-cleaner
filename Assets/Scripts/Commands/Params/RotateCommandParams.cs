using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RotateCommandParams : CommandParamsBase
{
    public Rotation RotationSide;
    
    public enum Rotation
    {
        Left,
        Right
    }
}
