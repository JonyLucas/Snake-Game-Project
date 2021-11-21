using Game.Player.Movement;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    private BaseMovement _baseMovementScript;

    private void Awake()
    {
        _baseMovementScript = gameObject.GetComponent<HeadMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _baseMovementScript.NextBodyBlock)
        {
            return;
        }
    }
}