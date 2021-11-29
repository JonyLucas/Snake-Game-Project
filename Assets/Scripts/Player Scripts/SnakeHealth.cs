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

        private bool _hasShield = false;
        private bool _isInvulnarable = false;

        [SerializeField]
        private float _shieldTime = 10;

        [SerializeField]
        private GameObject _shieldObject;

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
                    if (!_isInvulnarable)
                    {
                        SnakeDeath();
                    }
                }
            }
        }

        private void SnakeDeath()
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

        public void SpawnBodyBlock()
        {
            var snakeBodyObject = transform.parent
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.CompareTag("SnakeBody"));

            var newBlock = Instantiate(_bodyBlockPrefab, snakeBodyObject);
            newBlock.SetActive(false);
            _baseMovementScript.SetNextBodyBlock(newBlock);
        }

        public void AcquiredShield()
        {
            _hasShield = true;
        }

        public void EnableShield()
        {
            if (_hasShield && _shieldObject != null)
            {
                _hasShield = false;
                StartCoroutine(TemporaryInvulnerability());
            }
        }

        private IEnumerator TemporaryInvulnerability()
        {
            _isInvulnarable = true;
            _shieldObject.SetActive(true);
            yield return new WaitForSeconds(_shieldTime);
            _isInvulnarable = false;
            _shieldObject.SetActive(false);
        }
    }
}