using Game.Extensions;
using Game.ScriptableObjects;
using System.Linq;
using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        // Fields
        [SerializeField]
        private PlayerMoveData _moveData;

        [SerializeField]
        protected PlayerSprites _sprites;

        protected string _snakeTag = "Player";

        private float _speed;
        private float _stopMove;
        private float _xLimit;
        private float _yLimit;

        private bool _canChangeDirection;

        private Vector3 _previousPosition = Vector3.zero;
        private Vector2 _previousMoveDirection = Vector2.zero;
        private Vector2 _moveDirection = Vector2.right;

        protected new SpriteRenderer renderer;
        protected GameObject nextBodyBlock;

        // Properties
        public float Speed
        { get { return _speed; } }

        public float StopMove
        { get { return _stopMove; } }

        public bool CanChangeDirection
        { get { return _canChangeDirection; } }

        public GameObject NextBodyBlock
        { get { return nextBodyBlock; } }

        public Vector3 PreviousPosition
        { get { return _previousPosition; } }

        public Vector2 PreviousMoveDirection
        { get { return _previousMoveDirection; } }

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

            _canChangeDirection = true;

            renderer = GetComponent<SpriteRenderer>();

            SetSprites();
            SetNextBodyBlock();
        }

        protected abstract void SetSprites();

        public abstract void SetNextBodyBlock(GameObject nextBlock = null);

        protected virtual void Movement()
        {
            Translate();
            CheckSpaceLimits();
            UpdateBodyPositionAndDirection();
        }

        protected void Translate()
        {
            var newPosition = transform.localPosition;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            transform.localPosition = newPosition;
        }

        protected void CheckSpaceLimits()
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

        protected void UpdateBodyPositionAndDirection(bool isTurning = false)
        {
            _canChangeDirection = true;
            if (nextBodyBlock != null)
            {
                nextBodyBlock.GetComponent<BaseMovement>().Movement();
                if (isTurning)
                {
                    nextBodyBlock.GetComponent<BaseMovement>().ChangeDirection(_moveDirection);
                }
            }
        }

        /// <summary>
        /// Changes the direction of the snake's block, update its sprite and then update the subsequent block.
        /// </summary>
        /// <param name="newDirection"></param>
        public void ChangeDirection(Vector2 newDirection)
        {
            _canChangeDirection = false;
            _previousMoveDirection = _moveDirection;
            MoveDirection = newDirection;
            BlockTurnDirection();
        }

        /// <summary>
        /// This method updates the block's sprite according to the previous block direction.
        /// </summary>
        protected abstract void BlockTurnDirection();

        protected GameObject GetFirstSnakeElementByTag(string tag)
        {
            // Gets the player object that contains this gameObject's transform.
            var snakeTransform = GameObject.FindGameObjectsWithTag(_snakeTag)
                .FirstOrDefault(x => x.transform.GetComponentsInChildren<Transform>().Contains(transform));

            // Gets the first child with the specified tag.
            var childWithTag = snakeTransform.transform
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(x => x.CompareTag(tag));

            return childWithTag != null ? childWithTag.gameObject : null;
        }
    }
}