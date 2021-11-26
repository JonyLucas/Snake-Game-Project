using Game.Extensions;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        // Fields
        [SerializeField]
        private PlayerMoveData _moveData;

        private float _speed;
        private float _stopMove;
        private float _xLimit;
        private float _yLimit;

        private bool _isMoving;
        private bool _canChangeDirection;

        protected Vector2 previousMoveDirection = Vector2.zero;
        private Vector2 _moveDirection = Vector2.right;

        protected GameObject nextBodyBlock;

        // Properties
        public float BlockSize { get; set; }

        public bool CanChangeDirection
        { get { return _canChangeDirection; } }

        protected bool IsMoving
        { get { return _isMoving; } }

        protected float Speed
        { get { return _speed; } }

        public GameObject NextBodyBlock
        { get { return nextBodyBlock; } }

        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value.GetProminentVectorComponent(); }
        }

        private void Awake()
        {
            // Sets the player's movement data
            _speed = _moveData.Speed;
            _stopMove = _moveData.StopMove;
            _xLimit = _moveData.XLimit;
            _yLimit = _moveData.YLimit;

            _isMoving = false;
            _canChangeDirection = true;

            // Get the size of the block in Unity's Unit
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            BlockSize = renderer.sprite.rect.width / renderer.sprite.pixelsPerUnit;

            SetNextBodyBlock();
        }

        protected abstract void SetNextBodyBlock();

        private void Start()
        {
            StartCoroutine(Movement());
        }

        private IEnumerator Movement()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(_stopMove);
                _isMoving = true;

                Translate(); //transform.Translate(_moveDirection, Space.Self) Also Works
                CheckSpaceLimits();

                yield return new WaitForSeconds(0.01f);
                _isMoving = false;
            }
        }

        private void Translate()
        {
            var newPosition = transform.localPosition;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            transform.localPosition = newPosition;
        }

        private void CheckSpaceLimits()
        {
            if (Mathf.Abs(transform.localPosition.x) > _xLimit)
            {
                var xPosition = transform.localPosition.x > 0 ? -_xLimit : _xLimit;
                var yPosition = transform.localPosition.y;
                transform.localPosition = new Vector2(xPosition, yPosition);
            }

            if (Mathf.Abs(transform.localPosition.y) > _yLimit)
            {
                var xPosition = transform.localPosition.x;
                var yPosition = transform.localPosition.y > 0 ? -_yLimit : _yLimit;
                transform.localPosition = new Vector2(xPosition, yPosition);
            }
        }

        /// <summary>
        /// Changes the direction of the snake's block, update its sprite and then update the subsequent block.
        /// </summary>
        /// <param name="newDirection"></param>
        public void ChangeDirection(Vector2 newDirection)
        {
            StartCoroutine(ChangeDirectionCoroutine(newDirection));
        }

        /// <summary>
        /// This Coroutine is used to synchronize the change of direction with the time that the snake's block is moved.
        /// And also synchronize the player input with the movement rate of the snake's block (_stopMove).
        /// </summary>
        /// <param name="newDirection"></param>
        /// <returns></returns>
        private IEnumerator ChangeDirectionCoroutine(Vector2 newDirection)
        {
            _canChangeDirection = false;
            yield return new WaitUntil(() => !_isMoving);

            previousMoveDirection = _moveDirection;
            MoveDirection = newDirection;
            UpdateSnakeBlock();
        }

        protected abstract void UpdateSnakeBlock();

        protected void UpdateNextBlock()
        {
            _canChangeDirection = true;
            if (nextBodyBlock != null)
            {
                nextBodyBlock.GetComponent<BaseMovement>().ChangeDirection(_moveDirection);
            }
        }

        protected GameObject GetFirstSnakeElementByTag(string tag)
        {
            // Gets the player object that contains this gameObject's transform.
            var snakeTransform = GameObject.FindGameObjectsWithTag("Player")
                .FirstOrDefault(x => x.transform.GetComponentsInChildren<Transform>().Contains(transform));

            // Gets the first child with the specified tag.
            var childWithTag = snakeTransform.transform
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.CompareTag(tag));

            return childWithTag != null ? childWithTag.gameObject : null;
        }
    }
}