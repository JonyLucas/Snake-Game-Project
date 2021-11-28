using Game.Commands.MoveCommands;
using Game.Extensions;
using Game.Observer.Listeners;
using Game.Player.Movement;
using UnityEngine;

namespace Game.Enemy.AI
{
    /// <summary>
    /// This class is responsible to control the enemy behaviour. It should be associated with the enemy snake's head.
    /// </summary>
    public class EnemyAIBehaviour : MonoBehaviour
    {
        private GameObject _target;

        private readonly TurnUpCommand _turnUpCommand = new TurnUpCommand();
        private readonly TurnDownCommand _turnDownCommand = new TurnDownCommand();
        private readonly TurnRightCommand _turnRightCommand = new TurnRightCommand();
        private readonly TurnLeftCommand _turnLeftCommand = new TurnLeftCommand();

        private float _stopMoveRate;

        private void Start()
        {
            var moveScript = GetComponent<BaseMovement>();
            if (moveScript != null)
            {
                _stopMoveRate = moveScript.StopMove;
            }
            else
            {
                _stopMoveRate = 0;
            }

            InvokeRepeating("StartBehaviour", _stopMoveRate, _stopMoveRate);
        }

        public void SetDestination(GameObject collectable)
        {
            if (_target == null || !_target.activeInHierarchy)
            {
                _target = collectable;
            }
            else
            {
                // Sets the target to the nearest collectable
                var distanceTarget = transform.position - _target.transform.position;
                var distanceCollectable = transform.position - collectable.transform.position;
                if (distanceTarget.magnitude > distanceCollectable.magnitude)
                {
                    _target = collectable;
                }
            }
        }

        private void StartBehaviour()
        {
            if (_target == null || !_target.activeInHierarchy)
            {
                return;
            }

            var distanceDirection = CalculateDirection();
            ExecuteCommand(distanceDirection);
        }

        private Vector2 CalculateDirection()
        {
            var distance = transform.position - _target.transform.position;
            var distance2d = new Vector2(distance.x, distance.y);
            return distance2d.GetProminentVectorComponent();
        }

        private void ExecuteCommand(Vector2 distanceDirection)
        {
            if (distanceDirection == Vector2.up)
            {
                _turnUpCommand.Execute(gameObject);
            }
            else if (distanceDirection == Vector2.down)
            {
                _turnDownCommand.Execute(gameObject);
            }
            else if (distanceDirection == Vector2.right)
            {
                _turnRightCommand.Execute(gameObject);
            }
            else if (distanceDirection == Vector2.left)
            {
                _turnLeftCommand.Execute(gameObject);
            }
        }
    }
}