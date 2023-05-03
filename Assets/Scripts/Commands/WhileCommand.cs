using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileCommand : CommandBase
{
    private int _count;
    private List<CommandBase> _commands;
    private int _currentCommandIndex;

    public override void Initialize(CommandParamsBase param)
    {
        if (param is WhileCommandParams whileParam)
        {
            _commands = new List<CommandBase>();

            foreach (var commandSO in whileParam.Commands)
                _commands.Add(CommandManager.InstantiateCommand(commandSO));

            _count = whileParam.Count;
            _commands.ForEach(c => c.OnComplete += Execute);
        }
    }

    public override void Execute()
    {
        if (_currentCommandIndex >= _commands.Count)
        {
            _currentCommandIndex = 0;
            --_count;
        }
        
        if (_count == 0)
        {
            Complete();
            return;
        }
        
        _commands[_currentCommandIndex].Execute();
        ++_currentCommandIndex;
    }
}