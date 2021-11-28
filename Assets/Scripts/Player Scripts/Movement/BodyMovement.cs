using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
        private Sprite _turnFirstQuadrantSprite;
        private Sprite _turnSecondQuadrantSprite;
        private Sprite _turnThirdQuadrantSprite;
        private Sprite _turnFourthQuadrantSprite;
        private Sprite _verticalSprite;
        private Sprite _horizontalSprite;

        private bool _isTurning;
        private Sprite _nextSprite;

        protected override void SetSprites()
        {
            _turnFirstQuadrantSprite = _sprites.turnBodyFirstQuadrantSprite;
            _turnSecondQuadrantSprite = _sprites.turnBodySecondQuadrantSprite;
            _turnThirdQuadrantSprite = _sprites.turnBodyThirdQuadrantSprite;
            _turnFourthQuadrantSprite = _sprites.turnBodyFourthQuadrantSprite;
            _verticalSprite = _sprites.bodyVerticalSprite;
            _horizontalSprite = _sprites.bodyHorizontalSprite;

            // Set Player sprite
            if (MoveDirection == Vector2.up || MoveDirection == Vector2.down)
            {
                renderer.sprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.right || MoveDirection == Vector2.left)
            {
                renderer.sprite = _horizontalSprite;
            }
        }

        protected override void Movement()
        {
            if (_isTurning)
            {
                renderer.sprite = _nextSprite;
            }

            Translate();
            CheckSpaceLimits();
            UpdateBodyPositionAndDirection(_isTurning);
            _isTurning = false;
        }

        public override void SetNextBodyBlock(GameObject nextBlock = null)
        {
            if (nextBlock != null)
            {
                nextBodyBlock = nextBlock;
                return;
            }

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

        protected override void BlockTurnDirection()
        {
            if (PreviousMoveDirection == MoveDirection)
            {
                return;
            }

            _isTurning = true;

            if (MoveDirection == Vector2.up)
            {
                renderer.sprite = PreviousMoveDirection == Vector2.right ? _turnSecondQuadrantSprite : _turnFirstQuadrantSprite;
                _nextSprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.down)
            {
                renderer.sprite = PreviousMoveDirection == Vector2.right ? _turnThirdQuadrantSprite : _turnFourthQuadrantSprite;
                _nextSprite = _verticalSprite;
            }
            else if (MoveDirection == Vector2.right)
            {
                renderer.sprite = PreviousMoveDirection == Vector2.up ? _turnFourthQuadrantSprite : _turnFirstQuadrantSprite;
                _nextSprite = _horizontalSprite;
            }
            else if (MoveDirection == Vector2.left)
            {
                renderer.sprite = PreviousMoveDirection == Vector2.up ? _turnThirdQuadrantSprite : _turnSecondQuadrantSprite;
                _nextSprite = _horizontalSprite;
            }
        }

        /// <summary>
        /// This method updates the block's direction and sprite, according to the snake's head direction.
        /// This method should be utilized when a new block of the snake's body is instantiated.
        /// </summary>
        public void SyncWithHeadDirection()
        {
            var snakeHead = GetFirstSnakeElementByTag("SnakeHead");
            var moveScript = snakeHead.GetComponent<BaseMovement>();
            MoveDirection = moveScript.MoveDirection;

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