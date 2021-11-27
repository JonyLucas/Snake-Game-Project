using Game.ScriptableObjects.Events;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Observer.Listeners
{
    [Serializable]
    public class GenericEventListener<T> : MonoBehaviour where T : class
    {
        [SerializeField]
        private GenericGameEvent<T> _event;

        [SerializeField]
        private UnityEvent<T> _unityEvent;

        private void OnEnable()
        {
            _event.Register(this);
        }

        private void OnDisable()
        {
            _event.Unregister(this);
        }

        public void OnEventOccurs(T monoBehaviour)
        {
            _unityEvent.Invoke(monoBehaviour);
        }
    }
}