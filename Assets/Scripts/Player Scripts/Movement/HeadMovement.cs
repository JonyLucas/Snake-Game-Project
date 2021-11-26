using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class HeadMovement : BaseMovement
    {
        protected Sprite _upwardSprite;
        protected Sprite _downwardSprite;
        protected Sprite _backwardSprite;
        protected Sprite _forwardSprite;

        protected override void SetSprites()
        {
            _upwardSprite = _sprites.headUpwardSprite;
            _downwardSprite = _sprites.headDownwardSprite;
            _backwardSprite = _sprites.headBackwardSprite;
            _forwardSprite = _sprites.headForwardSprite;
        }

        protected override void SetNextBodyBlock()
        {
            nextBodyBlock = GetFirstSnakeElementByTag("SnakeBodyBlock");
        }

        protected override void UpdateSnakeBlock()
        {
            var renderer = GetComponent<SpriteRenderer>();
            var newPosition = transform.localPosition;
            var translatePosition = previousMoveDirection * Speed;

            if (MoveDirection == Vector2.up)
            {
                newPosition.y += BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _upwardSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                newPosition.y -= BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _downwardSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                newPosition.x += BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _forwardSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                newPosition.x -= BlockSize;
                transform.localPosition = newPosition;
                renderer.sprite = _backwardSprite;
            }

            UpdateBodyPosition(translatePosition);
            UpdateNextBlock();
        }

        private void UpdateBodyPosition(Vector3 translatePosition)
        {
            Debug.Log("Translate Body: " + translatePosition);
            var currentBlock = nextBodyBlock;
            while (currentBlock != null)
            {
                currentBlock.transform.localPosition += translatePosition;
                currentBlock = currentBlock.GetComponent<BaseMovement>().NextBodyBlock;
            }
        }
    }
}