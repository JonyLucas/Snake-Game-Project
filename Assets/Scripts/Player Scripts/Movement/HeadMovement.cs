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

        protected override void SetSprite()
        {
            var renderer = GetComponent<SpriteRenderer>();
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