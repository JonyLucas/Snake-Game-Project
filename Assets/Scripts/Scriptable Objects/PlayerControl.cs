using Game.Commands;
using Game.Commands.MoveCommands;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Control", menuName = "Player Control", order = 51)]
public class PlayerControl : ScriptableObject
{
    [SerializeField]
    private TurnDownCommand _turnDownCommand;

    [SerializeField]
    private TurnUpCommand _turnUpCommand;

    [SerializeField]
    private TurnLeftCommand _turnLeftCommand;

    [SerializeField]
    private TurnRightCommand _turnRightCommand;

    private readonly List<BaseCommand> _commands = new List<BaseCommand>();

    public List<BaseCommand> Commands
    {
        get
        {
            if (_commands.Count == 0)
            {
                InitializeMoveCommands();
            }
            return _commands;
        }
    }

    private void InitializeMoveCommands()
    {
        _commands.Add(_turnDownCommand);
        _commands.Add(_turnUpCommand);
        _commands.Add(_turnLeftCommand);
        _commands.Add(_turnRightCommand);
    }
}