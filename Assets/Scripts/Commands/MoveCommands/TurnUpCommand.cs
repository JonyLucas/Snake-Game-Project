using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnUpCommand : MovementCommand
    {
        public override Vector2 MoveDirection
        { get { return Vector2.up; } }
    }
}