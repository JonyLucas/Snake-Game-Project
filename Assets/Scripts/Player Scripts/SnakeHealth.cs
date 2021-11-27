using Game.Player.Movement;
using System.Linq;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    private HeadMovement _baseMovementScript;

    [SerializeField]
    private GameObject _bodyBlockPrefab;

    private void Awake()
    {
        _baseMovementScript = GetComponent<HeadMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnakeBodyBlock") || collision.CompareTag("SnakeTail"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void SpawnBodyBlock()
    {
        var snakeBodyObject = transform.parent
            .GetComponentsInChildren<Transform>()
            .FirstOrDefault(x => x.CompareTag("SnakeBody"));

        //var previousHeadPosition = transform.localPosition;
        var newBlock = Instantiate(_bodyBlockPrefab, snakeBodyObject);
        newBlock.SetActive(false);
        _baseMovementScript.SetNextBodyBlock(newBlock);
    }
}