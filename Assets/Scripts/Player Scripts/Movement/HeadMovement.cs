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

        private void Start()
        {
            InvokeRepeating("Movement", 0, StopMove); // Coroutine could be used as well
        }

        public override void SetNextBodyBlock(GameObject nextBlock = null)
        {
            if (nextBlock == null)
            {
                nextBodyBlock = GetFirstSnakeElementByTag("SnakeBodyBlock");
            }
            else
            {
                var nextBlockMoveScript = nextBlock.GetComponent<BodyMovement>();

                var oldNextBlock = NextBodyBlock;
                nextBodyBlock = nextBlock;
                nextBlock.transform.localPosition = transform.localPosition;

                UpdateHeadPosition();

                nextBlock.SetActive(true);
                nextBlockMoveScript.SyncWithHeadDirection();
                UpdateBodyPositionAndDirection();
                nextBlockMoveScript.SetNextBodyBlock(oldNextBlock);
            }
        }

        protected override void BlockTurnDirection()
        {
            UpdateHeadPosition();
            UpdateBodyPositionAndDirection(true);
        }

        public void UpdateHeadPosition()
        {
            var newPosition = transform.localPosition;

            if (MoveDirection == Vector2.up)
            {
                newPosition.y += Speed;
                transform.localPosition = newPosition;
                renderer.sprite = _upwardSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                newPosition.y -= Speed;
                transform.localPosition = newPosition;
                renderer.sprite = _downwardSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                newPosition.x += Speed;
                transform.localPosition = newPosition;
                renderer.sprite = _forwardSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                newPosition.x -= Speed;
                transform.localPosition = newPosition;
                renderer.sprite = _backwardSprite;
            }
        }
    }
}