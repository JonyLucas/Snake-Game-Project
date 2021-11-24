using Game.Commands;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerControl _playerControl;

    private readonly Dictionary<KeyCode, BaseCommand> _keyCommands = new Dictionary<KeyCode, BaseCommand>();

    private readonly List<KeyCode> _keys = new List<KeyCode>();

    private GameObject _snakeHead;

    private void Awake()
    {
        _playerControl.Commands
            .Where(x => x.AssociatedKey != KeyCode.None)
            .ToList()
            .ForEach(command =>
            {
                _keys.Add(command.AssociatedKey);
                _keyCommands.Add(command.AssociatedKey, command);
            });
    }

    private void Start()
    {
        _snakeHead = GameObject.FindGameObjectWithTag("SnakeHead");
    }

    private void Update()
    {
        var key = _keys?.FirstOrDefault(x => Input.GetKeyDown(x));
        if (key != null && key != KeyCode.None)
        {
            _keyCommands[key.Value].Execute(_snakeHead);
        }
    }
}