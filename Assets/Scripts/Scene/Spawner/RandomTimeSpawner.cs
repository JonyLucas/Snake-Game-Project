using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Spawner
{
    public class RandomTimeSpawner : BaseSpawner
    {
        [SerializeField]
        private float _minRange;

        [SerializeField]
        private float _maxRange;

        // Update is called once per frame
        private void Update()
        {
        }
    }
}