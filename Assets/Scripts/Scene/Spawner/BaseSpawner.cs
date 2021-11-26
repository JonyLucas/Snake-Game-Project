using System.Collections;
using UnityEngine;

namespace Game.Spawner
{
    public class BaseSpawner : MonoBehaviour
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

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        protected virtual IEnumerator SpawnCoroutine()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(_spwanTime);
            }
        }
    }
}