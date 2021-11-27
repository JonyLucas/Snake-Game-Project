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

        protected override void SetSprites()
        {
            _turnFirstQuadrantSprite = _sprites.turnBodyFirstQuadrantSprite;
            _turnSecondQuadrantSprite = _sprites.turnBodySecondQuadrantSprite;
            _turnThirdQuadrantSprite = _sprites.turnBodyThirdQuadrantSprite;
            _turnFourthQuadrantSprite = _sprites.turnBodyFourthQuadrantSprite;
            _verticalSprite = _sprites.bodyVerticalSprite;
            _horizontalSprite = _sprites.bodyHorizontalSprite;
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

        protected override void UpdateSnakeBlock()
        {
            Sprite turnSprite = null;
            Sprite nextSprite = null;

            if (PreviousMoveDirection != MoveDirection)
            {
                if (MoveDirection == Vector2.up)
                {
                    turnSprite = PreviousMoveDirection == Vector2.right ? _turnSecondQuadrantSprite : _turnFirstQuadrantSprite;
                    nextSprite = _verticalSprite;
                }
                else if (MoveDirection == Vector2.down)
                {
                    turnSprite = PreviousMoveDirection == Vector2.right ? _turnThirdQuadrantSprite : _turnFourthQuadrantSprite;
                    nextSprite = _verticalSprite;
                }
                else if (MoveDirection == Vector2.right)
                {
                    turnSprite = PreviousMoveDirection == Vector2.up ? _turnFourthQuadrantSprite : _turnFirstQuadrantSprite;
                    nextSprite = _horizontalSprite;
                }
                else if (MoveDirection == Vector2.left)
                {
                    turnSprite = PreviousMoveDirection == Vector2.up ? _turnThirdQuadrantSprite : _turnSecondQuadrantSprite;
                    nextSprite = _horizontalSprite;
                }
            }
            else
            {
                nextSprite = GetComponent<SpriteRenderer>().sprite;
            }

            StartCoroutine(SetTurnSprite(turnSprite, nextSprite));
        }

        /// <summary>
        /// This Coroutine keeps a temporary sprite with snake's movement time duration, then changes it to another sprite.
        /// </summary>
        /// <param name="tempSprite">Temporary Sprite</param>
        /// <param name="newSprite">New Sprite</param>
        /// <returns></returns>
        private IEnumerator SetTurnSprite(Sprite turnSprite, Sprite newSprite)
        {
            renderer.sprite = turnSprite != null ? turnSprite : newSprite;
            yield return new WaitUntil(() => IsMoving);
            renderer.sprite = newSprite;
            UpdateNextBlock();
        }

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