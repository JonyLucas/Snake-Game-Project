using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnLeftCommand : MovementCommand
    {
        public override Vector2 MoveDirection
        { get { return Vector2.left; } }
    }
}