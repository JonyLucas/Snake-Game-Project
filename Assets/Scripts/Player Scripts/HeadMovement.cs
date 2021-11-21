using System.Collections;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 100;

    [SerializeField]
    private float _stopMove = 0.2f;

    [SerializeField]
    private float _xLimit = 94;

    [SerializeField]
    private float _yLimit = 55;

    private Vector2 _moveDirection = Vector2.right;

    public Vector2 MoveDirection
    {
        get { return _moveDirection; }
        set
        {
            value = value.normalized;
            if (Mathf.Abs(value.x) > Mathf.Abs(value.y))
            {
                _moveDirection = value.x > 0 ? Vector2.right : Vector2.left;
            }
            else
            {
                _moveDirection = value.y > 0 ? Vector2.up : Vector2.down;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Movement());
    }

    /// <summary>
    /// Movement of the snake's head is implemented here.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Movement()
    {
        // Gives a second of waiting for the scene to build
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return new WaitForSeconds(_stopMove);
            transform.Translate(_moveDirection * _speed * Time.deltaTime);
            if (Mathf.Abs(transform.localPosition.x) > _xLimit)
            {
                var xPosition = transform.localPosition.x * (-1);
                var yPosition = transform.localPosition.y;
                transform.localPosition = new Vector2(xPosition, yPosition);
            }

            if (Mathf.Abs(transform.localPosition.y) > _yLimit)
            {
                var xPosition = transform.localPosition.x;
                var yPosition = transform.localPosition.y * (-1);
                transform.localPosition = new Vector2(xPosition, yPosition);
            }
        }
    }
}