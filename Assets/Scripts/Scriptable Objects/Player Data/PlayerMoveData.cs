using UnityEngine;

namespace Game.ScriptableObjects
{
    /**
     * This class centralizes the data for the player's movement, like speed, x and y limits.
     * The idea is to segregate the data from the movement logic, giving a single point of change for many objects that utilize these data.
     * So it's not necessary to change these data on each object or prefabs on the scene.
     */

    [CreateAssetMenu(fileName = "Player Move Data", menuName = "Player Move Data", order = 52)]
    public class PlayerMoveData : ScriptableObject
    {
        [SerializeField]
        private float _speed = 100;

        [SerializeField]
        private float _stopMove = 0.2f;

        [SerializeField]
        private float _xLimit = 94;

        [SerializeField]
        private float _yLimit = 55;

        public float Speed
        { get { return _speed; } }

        public float StopMove
        { get { return _stopMove; } }

        public float XLimit
        { get { return _xLimit; } }

        public float YLimit
        { get { return _yLimit; } }
    }
}