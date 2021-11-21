using System.Collections;
using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerMoveData _moveData;

        protected GameObject _nextBodyBlock;

        protected GameObject _previousBodyBlock;

        public GameObject NextBodyBlock
        { get { return _nextBodyBlock; } }

        public GameObject PreviousBodyBlock
        { get { return _previousBodyBlock; } }

        private float _speed;
        private float _stopMove;
        private float _xLimit;
        private float _yLimit;

        public float XLimit
        { get { return _xLimit; } }

        public float YLimit
        { get { return _yLimit; } }

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

        private void Awake()
        {
            // Sets the player's movement data
            _speed = _moveData.Speed;
            _stopMove = _moveData.StopMove;
            _xLimit = _moveData.XLimit;
            _yLimit = _moveData.YLimit;

            SetNextBodyBlock();
            SetPreviousBodyBlock();
        }

        protected abstract void SetNextBodyBlock();

        protected abstract void SetPreviousBodyBlock();

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
                CheckSpaceLimits();
            }
        }

        protected abstract void CheckSpaceLimits();
    }
}