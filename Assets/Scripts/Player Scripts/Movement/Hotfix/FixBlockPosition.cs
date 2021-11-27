using System.Linq;
using UnityEngine;

namespace Game.Player.Movement
{
    /// <summary>
    /// This class is used to fix the body when it breaks apart.
    /// It's a temporary solution to make sure the snake body doesn't tear apart.
    /// Attach this component to the snake object, not its body parts (head, body and tail).
    /// </summary>
    public class AdjustBodyMovement : MonoBehaviour
    {
        private Transform _snakeHead;
        private BaseMovement _movementScript;

        [SerializeField]
        private int _stepsByRepeat = 5;

        // Start is called before the first frame update
        private void Start()
        {
            _snakeHead = GetComponentsInChildren<Transform>().FirstOrDefault(x => x.CompareTag("SnakeHead"));
            _movementScript = _snakeHead.GetComponent<BaseMovement>();
            InvokeRepeating("VerifyAndAdjustBody", _movementScript.StopMove, _movementScript.StopMove * _stepsByRepeat); // Repeats the checking each n steps
        }

        private void VerifyAndAdjustBody()
        {
            var headDirection = _movementScript.MoveDirection;
        }
    }
}