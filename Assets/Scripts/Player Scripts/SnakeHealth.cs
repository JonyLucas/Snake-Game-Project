using Game.Player.Movement;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    private BaseMovement _baseMovementScript;

    [SerializeField]
    private GameObject _bodyBlockPrefab;

    private void Awake()
    {
        _baseMovementScript = GetComponent<HeadMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnakeBodyBlock"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        if (collision.CompareTag("Collectable"))
        {
        }
    }
}