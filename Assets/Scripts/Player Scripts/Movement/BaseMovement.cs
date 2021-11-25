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

        protected bool _turnSprite;
        private Sprite _nextSprite;
        private SpriteRenderer _renderer;

        private bool _isMoving;
        private bool _canChangeDirection;

        protected Vector2 previousMoveDirection = Vector2.zero;
        private Vector2 _moveDirection = Vector2.right;

        protected GameObject nextBodyBlock;

        // Properties
        public float BlockSize { get; set; }

        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value.GetProminentVectorComponent(); }
        }

        public bool CanChangeDirection
        { get { return _canChangeDirection; } }

        public bool IsMoving
        { get { return _isMoving; } }

        public float StopMove
        { get { return _stopMove; } }

        protected float Speed
        { get { return _speed; } }

        private void Awake()
        {
            // Sets the player's movement data
            _speed = _moveData.Speed;
            _stopMove = _moveData.StopMove;
            _xLimit = _moveData.XLimit;
            _yLimit = _moveData.YLimit;

            _isMoving = false;
            _canChangeDirection = true;

            // TODO Verifying
            _turnSprite = false;
            _renderer = gameObject.GetComponent<SpriteRenderer>();

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
                _isMoving = false;
                yield return new WaitForSeconds(_stopMove);
                _isMoving = true;

                Translate(); //transform.Translate(_moveDirection, Space.Self) Also Works
                CheckSpaceLimits();
                CheckIsTurnBlock();
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

        private void CheckIsTurnBlock()
        {
            if (_turnSprite)
            {
                _turnSprite = false;
                _renderer.sprite = _nextSprite;
                StartCoroutine(UpdateNextBlock());
            }
        }

        /// <summary>
        /// This Coroutine keeps a temporary sprite with snake's movement time duration, then changes it to another sprite.
        /// </summary>
        /// <param name="tempSprite">Temporary Sprite</param>
        /// <param name="newSprite">New Sprite</param>
        /// <returns></returns>
        protected void SetTurnSprite(Sprite turnSprite, Sprite newSprite)
        {
            _renderer.sprite = turnSprite;
            _turnSprite = true;
            _nextSprite = newSprite;
        }

        /// <summary>
        /// Updates the next block of the snake's body, it has to have a little time delay, because each block updates its movement simultaneously.
        /// So when the next block updates its sprite, it'll coincide with the movement refresh time, and will update the next block simultaneously.
        /// </summary>
        /// <returns></returns>
        protected IEnumerator UpdateNextBlock()
        {
            if (nextBodyBlock != null)
            {
                yield return new WaitForSeconds(float.MinValue);
                nextBodyBlock.GetComponent<BaseMovement>().ChangeDirection(_moveDirection);
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
            _canChangeDirection = true;
        }

        protected abstract void UpdateSnakeBlock();

        //protected void UpdateNextBlock()
        //{
        //    //Updates the next block
        //    if (nextBodyBlock != null)
        //    {
        //        nextBodyBlock.GetComponent<BaseMovement>().ChangeDirection(_moveDirection);
        //    }
        //}

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