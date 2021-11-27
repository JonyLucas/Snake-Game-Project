using Game.ScriptableObjects;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Spawner
{
    public class BaseSpawner : MonoBehaviour
    {
        [SerializeField]
        protected SpawnerData spawnerData;

        protected float spwanTime;
        protected bool spawnCondition = true;
        protected GameObject spawnObjectPrefab;
        protected int instancesLimit;
        protected float xLimit;
        protected float yLimit;

        // Object Pooling
        protected GameObject[] instances;

        private void Start()
        {
            SetData();
            InitilizeObjectPooling();
            StartCoroutine(SpawnObjectCoroutine());
        }

        protected virtual void SetData()
        {
            spwanTime = spawnerData.SpawnTime;
            spawnObjectPrefab = spawnerData.SpawnObjectPrefab;
            instancesLimit = spawnerData.InstancesLimit;
            xLimit = spawnerData.XLimit;
            yLimit = spawnerData.YLimit;
        }

        private void InitilizeObjectPooling()
        {
            if (instancesLimit == 0)
            {
                return;
            }

            var parent = new GameObject(spawnObjectPrefab.name);
            parent = Instantiate(parent);
            instances = new GameObject[instancesLimit];
            for (int i = 0; i < instancesLimit; i++)
            {
                var instance = Instantiate(spawnObjectPrefab, parent.transform);
                instance.SetActive(false);
                instances[i] = instance;
            }
        }

        protected virtual IEnumerator SpawnObjectCoroutine()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(spwanTime);
                SpawnInPosition();
            }
        }

        protected void SpawnInPosition()
        {
            if (!spawnCondition)
            {
                return;
            }

            var newPosition = Vector3.zero;
            newPosition.x = Random.Range(-xLimit, xLimit);
            newPosition.y = Random.Range(-yLimit, yLimit);

            if (instances != null)
            {
                var instance = instances.FirstOrDefault(x => !x.activeInHierarchy); //It would be useful to use null propagation, but Unity advises to not use it.
                if (instance != null)
                {
                    instance.SetActive(true);
                    instance.transform.position = newPosition;
                }
            }
            else
            {
                Instantiate(spawnObjectPrefab, newPosition, Quaternion.identity);
            }
        }
    }
}