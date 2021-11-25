using UnityEngine;

namespace Game.Player.Movement
{
    public class TurnBlockMovement : MonoBehaviour
    {
        [SerializeField]
        private Sprite _turnFirstQuadrantSprite;

        [SerializeField]
        private Sprite _turnSecondQuadrantSprite;

        [SerializeField]
        private Sprite _turnThirdQuadrantSprite;

        [SerializeField]
        private Sprite _turnFourthQuadrantSprite;

        private Vector2 _newDirection;

        private Vector3 _newPosition;

        public void SetDirectionAndPosition(Vector3 newPosition, Vector2 previousDirection, Vector2 newDirection)
        {
            _newPosition = newPosition;
            _newDirection = newDirection;
            var renderer = GetComponent<SpriteRenderer>();

            if (newDirection == Vector2.up)
            {
                renderer.sprite = previousDirection == Vector2.right ? _turnSecondQuadrantSprite : _turnFirstQuadrantSprite;
            }
            else if (newDirection == Vector2.down)
            {
                renderer.sprite = previousDirection == Vector2.right ? _turnThirdQuadrantSprite : _turnFourthQuadrantSprite;
            }
            else if (newDirection == Vector2.right)
            {
                renderer.sprite = previousDirection == Vector2.up ? _turnFourthQuadrantSprite : _turnFirstQuadrantSprite;
            }
            else if (newDirection == Vector2.left)
            {
                renderer.sprite = previousDirection == Vector2.up ? _turnThirdQuadrantSprite : _turnSecondQuadrantSprite;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SnakeTail") || collision.CompareTag("SnakeBodyBlock"))
            {
                var moveScript = collision.GetComponent<BaseMovement>();
                moveScript.ChangeDirection(_newDirection);
                collision.transform.localPosition = _newPosition;
                if (collision.CompareTag("SnakeTail"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}