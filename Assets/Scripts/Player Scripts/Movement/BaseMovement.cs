using Game.Extensions;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerMoveData _moveData;

        private float _speed;
        private float _stopMove;
        private float _xLimit;
        private float _yLimit;
        private SpriteRenderer _renderer;

        protected Vector2 previousMoveDirection = Vector2.zero;
        private Vector2 _moveDirection = Vector2.right;

        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value.GetProminentVectorComponent(); }
        }

        protected GameObject nextBodyBlock;

        public GameObject NextBodyBlock
        { get { return nextBodyBlock; } }

        private void Awake()
        {
            // Sets the player's movement data
            _speed = _moveData.Speed;
            _stopMove = _moveData.StopMove;
            _xLimit = _moveData.XLimit;
            _yLimit = _moveData.YLimit;

            _renderer = gameObject.GetComponent<SpriteRenderer>();

            SetNextBodyBlock();
        }

        protected abstract void SetNextBodyBlock();

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
                Translate(); //transform.Translate(_moveDirection, Space.Self) Also Works
                CheckSpaceLimits();
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

        public void ChangeDirection(Vector2 newDirection)
        {
            MoveDirection = newDirection;
            SetSprite();
            StartCoroutine(UpdateNextBlock());
        }

        protected abstract void SetSprite();

        private IEnumerator UpdateNextBlock()
        {
            yield return new WaitForSeconds(_stopMove);
            if (nextBodyBlock != null)
            {
                nextBodyBlock.GetComponent<BaseMovement>().ChangeDirection(_moveDirection);
            }
        }

        /// <summary>
        /// This Coroutine keeps a temporary sprite with snake's movement time duration, then changes it to another sprite.
        /// </summary>
        /// <param name="tempSprite">Temporary Sprite</param>
        /// <param name="newSprite">New Sprite</param>
        /// <returns></returns>
        protected IEnumerator KeepSpriteForSeconds(Sprite tempSprite, Sprite newSprite)
        {
            _renderer.sprite = tempSprite;
            yield return new WaitForSeconds(_stopMove);
            _renderer.sprite = newSprite;
        }
    }
}