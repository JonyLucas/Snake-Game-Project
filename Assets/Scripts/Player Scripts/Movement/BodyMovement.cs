using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
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

        public override void UpdateSnakeBlock()
        {
            var renderer = GetComponent<SpriteRenderer>();

            if (MoveDirection == Vector2.up || MoveDirection == Vector2.down)
            {
                renderer.sprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.right || MoveDirection == Vector2.left)
            {
                renderer.sprite = _horizontalSprite;
            }
        }
    }
}