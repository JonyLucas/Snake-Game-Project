using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
        [SerializeField]
        private Sprite _turnUpwardSprite;

        [SerializeField]
        private Sprite _turnDownwardSprite;

        [SerializeField]
        private Sprite _turnBackwardSprite;

        [SerializeField]
        private Sprite _turnForwardSprite;

        [SerializeField]
        private Sprite _verticalSprite;

        [SerializeField]
        private Sprite _altVerticalSprite;

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
            Sprite turnSprite;
            Sprite nextSprite;

            if (MoveDirection == Vector2.up)
            {
                turnSprite = _turnUpwardSprite;
                nextSprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                turnSprite = _turnUpwardSprite; //TODO Change later
                nextSprite = _altVerticalSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                turnSprite = _turnUpwardSprite; //TODO Change later
                nextSprite = _horizontalSprite;
            }
            else
            {
                turnSprite = _turnUpwardSprite; //TODO Change later
                nextSprite = _horizontalSprite;
            }

            SetTurnSprite(turnSprite, nextSprite);
        }
    }
}