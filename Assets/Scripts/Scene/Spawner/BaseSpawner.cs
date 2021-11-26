using Game.ScriptableObjects;
using System.Collections;
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
        protected float xLimit;
        protected float yLimit;

        // Start is called before the first frame update
        private void Start()
        {
            SetData();
            StartCoroutine(SpawnObjectCoroutine());
        }

        protected virtual void SetData()
        {
            spwanTime = spawnerData.SpawnTime;
            spawnObjectPrefab = spawnerData.SpawnObjectPrefab;
            xLimit = spawnerData.XLimit;
            yLimit = spawnerData.YLimit;
        }

        protected virtual IEnumerator SpawnObjectCoroutine()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(spwanTime);
                if (spawnCondition)
                {
                    var newPosition = Vector3.zero;
                    newPosition.x = Random.Range(-xLimit, xLimit);
                    newPosition.y = Random.Range(-yLimit, yLimit);
                    Instantiate(spawnObjectPrefab, newPosition, Quaternion.identity);
                }
            }
        }
    }
}