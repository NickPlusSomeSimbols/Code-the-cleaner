using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandBase
{
    public event Action OnComplete;

    public virtual void Complete() => OnComplete?.Invoke();

    public virtual void Initialize(CommandParamsBase param)
    {
        
    }
    
    public abstract void Execute();
}
