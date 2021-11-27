using System.Collections;
using UnityEngine;

namespace Game.Spawner
{
    public class RandomTimeSpawner : BaseSpawner
    {
        private float _minTimeRange;
        private float _maxTimeRange;

        protected override void SetData()
        {
            base.SetData();
            _minTimeRange = spawnerData.MinTimeRange;
            _maxTimeRange = spawnerData.MaxTimeRange;
        }

        protected override IEnumerator SpawnObjectCoroutine()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(spwanTime);
                spwanTime = Random.Range(_minTimeRange, _maxTimeRange);
                SpawnInPosition();
            }
        }
    }
}