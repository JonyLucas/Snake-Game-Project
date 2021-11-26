using UnityEngine;

namespace Game.ScriptableObjects
{
    public class SpawnerData : ScriptableObject
    {
        [SerializeField]
        protected float _spwanTime = 1;

        [SerializeField]
        private bool _spawnCondition = true;

        [SerializeField]
        private GameObject _spawnObjectPrefab;

        [SerializeField]
        private float _xLimit;

        [SerializeField]
        private float _yLimit;
    }
}