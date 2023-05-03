using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public static CommandManager Instance;

    [SerializeField] private List<CommandSO> _commands;

    private int _currentCommandIndex;

    private void Start()
    {
        Instance = this;
        Invoke("Execute", 1);
    }

    public void Execute()
    {
        if(_currentCommandIndex < _commands.Count)
        {
            var command = InstantiateCommand(_commands[_currentCommandIndex++]);
            command.OnComplete += Execute;
            command.Execute();
        }
    }

    public static CommandBase InstantiateCommand(CommandSO commandSO)
    {
        CommandBase command = null;
        
        switch (commandSO)
        {
            case ForwardCommandSO:
                var forwardCommand = new ForwardCommand();
                forwardCommand.Initialize(null);
                command = forwardCommand;
                break; 
                
            case RotateCommandSO rotateSO:
                var rotateCommand = new RotateCommand();
                rotateCommand.Initialize(rotateSO.Params);
                command = rotateCommand;
                break;

            case WhileCommandSO whileSO:
                var whileCommand = new WhileCommand();
                whileCommand.Initialize(whileSO.Params);
                command = whileCommand;
                break;
        }

        return command;
    }
}
