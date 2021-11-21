﻿using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnRightCommand : MovementCommand
    {
        public override Vector2 MoveDirection
        { get { return Vector2.right; } }

        protected override void SetHeadPosition(GameObject gameObject)
        {
            var newPosition = gameObject.transform.localPosition;
            newPosition.x += 5;
            gameObject.transform.localPosition = newPosition;
        }
    }
}