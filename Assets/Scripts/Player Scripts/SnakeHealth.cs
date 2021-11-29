using Game.Player.Movement;
using Game.ScriptableObjects.Events;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Player
{
    public class SnakeHealth : MonoBehaviour
    {
        private HeadMovement _baseMovementScript;

        [SerializeField]
        private GameObject _bodyBlockPrefab;

        [SerializeField]
        private GameEvent _gameOverSPEvent;

        [SerializeField]
        private GameObjectEvent _gameOverMPEvent;

        private bool _isMultiplayer;

        private void Start()
        {
            _baseMovementScript = GetComponent<HeadMovement>();
            _isMultiplayer = GameObject.FindGameObjectsWithTag("Player").Length > 1;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SnakeBodyBlock") || collision.CompareTag("SnakeTail"))
            {
                if (collision.gameObject != _baseMovementScript.NextBodyBlock)
                {
                    if (_isMultiplayer)
                    {
                        if (_gameOverMPEvent != null)
                        {
                            _gameOverMPEvent.OnOcurred(this.gameObject);
                        }
                    }
                    else
                    {
                        if (_gameOverSPEvent != null)
                        {
                            _gameOverSPEvent.OnOcurred();
                        }
                    }

                    Destroy(gameObject.transform.parent.gameObject);
                }
            }
        }

        public void SpawnBodyBlock()
        {
            var snakeBodyObject = transform.parent
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.CompareTag("SnakeBody"));

            var newBlock = Instantiate(_bodyBlockPrefab, snakeBodyObject);
            newBlock.SetActive(false);
            _baseMovementScript.SetNextBodyBlock(newBlock);
        }
    }
}