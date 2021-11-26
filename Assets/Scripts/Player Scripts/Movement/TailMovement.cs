using Game.Player.Movement;
using UnityEngine;

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
    }

    protected override void SetNextBodyBlock()
    {
        nextBodyBlock = null;
    }

    protected override void UpdateSnakeBlock()
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