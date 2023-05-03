using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCommand : CommandBase
{
    public override void Execute()
    {
        PlayerController.Instance.OnCommandCompleted += Complete;
        PlayerController.Instance.MoveForward();
    }

    public override void Complete()
    {
        base.Complete();
        PlayerController.Instance.OnCommandCompleted -= Complete;
    }
}
