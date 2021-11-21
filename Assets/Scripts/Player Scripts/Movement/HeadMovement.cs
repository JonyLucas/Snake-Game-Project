using System.Linq;
using UnityEngine;

namespace Game.Player.Movement
{
    public class HeadMovement : BaseMovement
    {
        protected override void SetNextBodyBlock()
        {
            // Gets the first block of the snake's body
            var parentTransform = transform.parent.transform;

            var bodyTransform = parentTransform.GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.tag == "SnakeBody");

            _nextBodyBlock = bodyTransform?.GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.tag == "SnakeBodyBlock")?.gameObject;
        }

        protected override void SetPreviousBodyBlock()
        {
            // Sets the previous block as null, because the head is the first block.
            _previousBodyBlock = null;
        }

        protected override void CheckSpaceLimits()
        {
            if (Mathf.Abs(transform.localPosition.x) > XLimit)
            {
                var xPosition = transform.localPosition.x * (-1);
                var yPosition = transform.localPosition.y;
                transform.localPosition = new Vector2(xPosition, yPosition);
            }

            if (Mathf.Abs(transform.localPosition.y) > YLimit)
            {
                var xPosition = transform.localPosition.x;
                var yPosition = transform.localPosition.y * (-1);
                transform.localPosition = new Vector2(xPosition, yPosition);
            }
        }
    }
}