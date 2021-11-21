using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public abstract class MovementCommand : BaseCommand
    {
        [SerializeField]
        private Sprite _sprite;

        public abstract Vector2 MoveDirection { get; }

        public override void Execute(GameObject gameObject)
        {
            if (ExecutionCodition(gameObject))
            {
                SetSprite(gameObject);
                SetDirection(gameObject);
            }
        }

        private bool ExecutionCodition(GameObject gameObject)
        {
            return true;
        }

        private void SetSprite(GameObject gameObject)
        {
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = _sprite;
        }

        private void SetDirection(GameObject gameObject)
        {
            var moveScript = gameObject.GetComponent<HeadMovement>();
            moveScript.MoveDirection = MoveDirection;
        }
    }
}