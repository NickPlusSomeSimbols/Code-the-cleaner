using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : CommandBase
{
    private RotateCommandParams.Rotation _rotation;
    
    public override void Initialize(CommandParamsBase param)
    {
        if (param is RotateCommandParams rotateParams)
        {
            _rotation = rotateParams.RotationSide;
        }
    }

    public override void Execute()
    {
        PlayerController.Instance.OnCommandCompleted += Complete;
        
        if(_rotation == RotateCommandParams.Rotation.Left)
            PlayerController.Instance.RotateLeft();
        else
            PlayerController.Instance.RotateRight();
    }

    public override void Complete()
    {
        base.Complete();
        PlayerController.Instance.OnCommandCompleted -= Complete;
    }
}
