using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnDownCommand : MovementCommand
    {
        public override Vector2 MoveDirection
        { get { return Vector2.down; } }
    }
}