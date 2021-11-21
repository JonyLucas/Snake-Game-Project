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

        /// <summary>
        /// Expresses the condition to perform the action of the Command.
        /// In this case, it makes sure the player can't turn the snake's head in opposite directions.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns>Evaluated Condition</returns>
        protected bool ExecutionCodition(GameObject gameObject)
        {
            var moveScript = gameObject.GetComponent<HeadMovement>();
            var moveDirection = moveScript.MoveDirection;
            return MoveDirection != moveDirection && moveDirection != MoveDirection * (-1);
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