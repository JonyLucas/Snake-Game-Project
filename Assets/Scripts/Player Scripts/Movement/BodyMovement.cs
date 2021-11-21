using UnityEngine;

namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
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

        protected override void SetNextBodyBlock()
        {
        }

        protected override void SetPreviousBodyBlock()
        {
        }
    }
}