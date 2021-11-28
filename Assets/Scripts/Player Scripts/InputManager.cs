using Game.Commands;
using Game.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Player.PlayerInput
{
    /// <summary>
    /// This class reads the player's input and execute the commands associated with the pressed key,
    /// moving the player's snake or executing a powerup.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl _playerControl;

        [SerializeField]
        private GameObject _snakeHead;

        private Dictionary<KeyCode, BaseCommand> _keyCommands;

        private List<KeyCode> _keys;

        private bool _isInitialized = false;

        public void SetHeadAndControl(GameObject snake, PlayerControl control)
        {
            var snakeHead = snake.transform
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.CompareTag("SnakeHead"));

            _snakeHead = snakeHead.gameObject;
            _playerControl = control;
            InitilizeCommands();
        }

        private void InitilizeCommands()
        {
            _keyCommands = new Dictionary<KeyCode, BaseCommand>();
            _keys = new List<KeyCode>();

            _playerControl.Commands
                .Where(x => x.AssociatedKey != KeyCode.None)
                .ToList()
                .ForEach(command =>
                {
                    _keys.Add(command.AssociatedKey);
                    _keyCommands.Add(command.AssociatedKey, command);
                });

            _isInitialized = true;
        }

        private void Update()
        {
            if (_isInitialized)
            {
                var key = _keys?.FirstOrDefault(x => Input.GetKeyDown(x));
                if (key != null && key != KeyCode.None)
                {
                    _keyCommands[key.Value].Execute(_snakeHead);
                }
            }
        }
    }
}