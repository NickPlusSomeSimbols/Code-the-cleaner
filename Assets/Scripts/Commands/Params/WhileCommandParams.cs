using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WhileCommandParams : CommandParamsBase
{
    public int Count;
    public List<CommandSO> Commands;
}
