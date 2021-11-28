using UnityEngine;

namespace Game.Player.Movement
{
    public class TailMovement : BaseMovement
    {
        protected Sprite _upwardSprite;
        protected Sprite _downwardSprite;
        protected Sprite _backwardSprite;
        protected Sprite _forwardSprite;

        protected override void SetSprites()
        {
            _upwardSprite = _sprites.tailUpwardSprite;
            _downwardSprite = _sprites.tailDownwardSprite;
            _backwardSprite = _sprites.tailBackwardSprite;
            _forwardSprite = _sprites.tailForwardSprite;

            // Set Player sprite
            if (MoveDirection == Vector2.up)
            {
                renderer.sprite = _upwardSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                renderer.sprite = _downwardSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                renderer.sprite = _forwardSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                renderer.sprite = _backwardSprite;
            }
        }

        public override void SetNextBodyBlock(GameObject nextBlock = null)
        {
            // Gets the tag of the root GameObject that compose the snake
            _snakeTag = transform.parent.tag;

            nextBodyBlock = null;
        }

        protected override void BlockTurnDirection()
        {
            if (MoveDirection == Vector2.up)
            {
                renderer.sprite = _upwardSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                renderer.sprite = _downwardSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                renderer.sprite = _forwardSprite;
            }
            else
            {
                renderer.sprite = _backwardSprite;
            }
        }
    }
}