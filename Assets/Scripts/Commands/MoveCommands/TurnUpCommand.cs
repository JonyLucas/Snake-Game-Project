using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnUpCommand : MovementCommand
    {
        public override Vector2 MoveDirection
        { get { return Vector2.up; } }

        protected override void SetHeadPosition(GameObject gameObject)
        {
            var newPosition = gameObject.transform.localPosition;
            newPosition.y += 5;
            gameObject.transform.localPosition = newPosition;
        }
    }
}