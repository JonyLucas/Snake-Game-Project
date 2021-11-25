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

        [SerializeField]
        private GameObject _turnBodyBlockPrefab;

        private Vector3 _previousPosition;

        protected override void SetNextBodyBlock()
        {
            nextBodyBlock = GetFirstSnakeElementByTag("SnakeBodyBlock");
        }

        public override void UpdateSnakeBlock()
        {
            var renderer = GetComponent<SpriteRenderer>();
            _previousPosition = transform.localPosition;
            var newPosition = transform.localPosition;

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

            CreateTurnBlock();
        }

        private void CreateTurnBlock()
        {
            var turnBlock = Instantiate(_turnBodyBlockPrefab, transform.parent);
            turnBlock.transform.localPosition = _previousPosition;
            turnBlock.GetComponent<TurnBlockMovement>().SetDirectionAndPosition(transform.localPosition, previousMoveDirection, MoveDirection);
        }
    }
}