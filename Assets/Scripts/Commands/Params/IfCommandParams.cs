using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IfCommandParams : CommandParamsBase
{
    public IfCommandCondition Condition;
    public List<CommandBase> Commands;
}

public enum IfCommandCondition
{
    Obstacle,
    Station
}