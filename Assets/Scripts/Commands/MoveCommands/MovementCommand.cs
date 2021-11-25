using Game.Player.Movement;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public abstract class MovementCommand : BaseCommand
    {
        public abstract Vector2 MoveDirection { get; }

        public override void Execute(GameObject gameObject)
        {
            if (ExecutionCodition(gameObject))
            {
                var moveScript = gameObject.GetComponent<BaseMovement>();
                moveScript.ChangeDirection(MoveDirection);
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
            if (gameObject != null)
            {
                var moveScript = gameObject.GetComponent<HeadMovement>();
                var snakeMoveDirection = moveScript.MoveDirection;
                var isValidDirection = snakeMoveDirection != MoveDirection && snakeMoveDirection != MoveDirection * (-1);
                return isValidDirection && moveScript.CanChangeDirection;
            }

            return false;
        }
    }
}