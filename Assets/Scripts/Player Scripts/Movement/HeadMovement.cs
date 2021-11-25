using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class HeadMovement : BaseMovement
    {
        [SerializeField]
        protected Sprite _upwardSprite;

        [SerializeField]
        protected Sprite _downwardSprite;

        [SerializeField]
        protected Sprite _backwardSprite;

        [SerializeField]
        protected Sprite _forwardSprite;

        protected override void SetNextBodyBlock()
        {
            nextBodyBlock = GetFirstSnakeElementByTag("SnakeBodyBlock");
        }

        protected override void UpdateSnakeBlock()
        {
            var renderer = GetComponent<SpriteRenderer>();
            var newPosition = transform.localPosition;

            if (MoveDirection == Vector2.up)
            {
                newPosition.x += previousMoveDirection == Vector2.right ? -BlockSize : BlockSize;
                newPosition.y += BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _upwardSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                newPosition.x += previousMoveDirection == Vector2.right ? -BlockSize : BlockSize;
                newPosition.y -= BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _downwardSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                newPosition.x += BlockSize;
                newPosition.y += previousMoveDirection == Vector2.up ? -BlockSize : BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _forwardSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                newPosition.x -= BlockSize;
                newPosition.y += previousMoveDirection == Vector2.up ? -BlockSize : BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _backwardSprite;
            }

            UpdateNextBlock();
            canChangeDirection = true;
        }
    }
}