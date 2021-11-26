using UnityEngine;

namespace Game.ScriptableObjects
{
    /// <summary>
    /// The intention of using scriptable objects here is to make sure these data persists and can be used in other scenes on the future.
    /// It reduces the necessity of creating multiple Prefabs, with the same behaviour, witch have different datas, and having to manipulate each of these between the scenes.
    /// </summary>
    [CreateAssetMenu(fileName = "Spawner Data", menuName = "Spawner Data", order = 54)]
    public class SpawnerData : ScriptableObject
    {
        [SerializeField]
        protected float _spwanTime = 1;

        [SerializeField]
        private GameObject _spawnObjectPrefab;

        [SerializeField]
        private float _xLimit;

        [SerializeField]
        private float _yLimit;

        [SerializeField]
        private float _minTimeRange;

        [SerializeField]
        private float _maxTimeRange;

        public float SpawnTime
        { get { return _spwanTime; } }

        public GameObject SpawnObjectPrefab
        { get { return _spawnObjectPrefab; } }

        public float XLimit
        { get { return _xLimit; } }

        public float YLimit
        { get { return _yLimit; } }

        public float MinTimeRange
        { get { return _minTimeRange; } }

        public float MaxTimeRange
        { get { return _maxTimeRange; } }
    }
}