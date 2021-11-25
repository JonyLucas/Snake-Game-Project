using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
        [SerializeField]
        private Sprite _turnFirstQuadrantSprite;

        [SerializeField]
        private Sprite _turnSecondQuadrantSprite;

        [SerializeField]
        private Sprite _turnThirdQuadrantSprite;

        [SerializeField]
        private Sprite _turnFourthQuadrantSprite;

        [SerializeField]
        private Sprite _verticalSprite;

        [SerializeField]
        private Sprite _horizontalSprite;

        protected override void SetNextBodyBlock()
        {
            var index = transform.GetSiblingIndex();
            if (index == transform.parent.childCount - 1)
            {
                nextBodyBlock = GetFirstSnakeElementByTag("SnakeTail");
            }
            else
            {
                var child = transform.parent.GetChild(index + 1);
                nextBodyBlock = child != null ? child.gameObject : null;
            }
        }

        protected override void UpdateSnakeBlock()
        {
            Sprite turnSprite = null;
            Sprite nextSprite = null;

            if (MoveDirection == Vector2.up)
            {
                turnSprite = previousMoveDirection == Vector2.right ? _turnSecondQuadrantSprite : _turnFirstQuadrantSprite;
                nextSprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                turnSprite = previousMoveDirection == Vector2.right ? _turnThirdQuadrantSprite : _turnFourthQuadrantSprite;
                nextSprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                turnSprite = previousMoveDirection == Vector2.up ? _turnFourthQuadrantSprite : _turnFirstQuadrantSprite;
                nextSprite = _horizontalSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                turnSprite = previousMoveDirection == Vector2.up ? _turnThirdQuadrantSprite : _turnSecondQuadrantSprite;
                nextSprite = _horizontalSprite;
            }

            SetTurnSprite(turnSprite, nextSprite);
        }
    }
}