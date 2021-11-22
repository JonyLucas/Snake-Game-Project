using Game.Extensions;
using Game.Player.Movement;
using UnityEngine;

public class TurnBodyBlock : MonoBehaviour
{
    [SerializeField]
    private Sprite _newBodyBlockSprite;

    [SerializeField]
    private Vector2 _moveDirection = Vector2.right;

    public Vector2 MoveDirection
    {
        get { return _moveDirection.GetProminentVectorComponent(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "SnakeBodyBlock")
        {
            var moveScript = collision.GetComponent<BodyMovement>();
            moveScript.MoveDirection = MoveDirection;

            var renderer = collision.GetComponent<SpriteRenderer>();
            renderer.sprite = _newBodyBlockSprite;

            //var newPosition = transform.localPosition;
            //newPosition.y += 5.4f;
            //collision.transform.position = newPosition;
        }
    }
}