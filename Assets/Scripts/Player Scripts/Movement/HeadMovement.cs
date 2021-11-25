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

        public override void ChangeDirection(Vector2 newDirection)
        {
            base.ChangeDirection(newDirection);
            StartCoroutine(UpdateNextBlock());
        }

        protected override void UpdateSnakeBlock()
        {
            var renderer = GetComponent<SpriteRenderer>();
            var newPosition = transform.localPosition;
            var translatePosition = previousMoveDirection * BlockSize;

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
        }

        private void UpdateBodyPosition(Vector3 translatePosition)
        {
            Debug.Log("Translate Body: " + translatePosition);
            var currentBlock = nextBodyBlock;
            while (true)
            {
                currentBlock.transform.localPosition += translatePosition;
                if (currentBlock.CompareTag("SnakeTail"))
                {
                    break;
                }
                currentBlock = currentBlock.GetComponent<BaseMovement>().NextBodyBlock;
            }
        }
    }
}