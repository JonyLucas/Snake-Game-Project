using Game.ScriptableObjects.Events;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Observer.Listeners
{
    [Serializable]
    public class EventListener : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _event;

        [SerializeField]
        private UnityEvent _unityEvent;

        private void OnEnable()
        {
            _event.Register(this);
        }

        private void OnDisable()
        {
            _event.Unregister(this);
        }

        public void OnEventOccurs()
        {
            _unityEvent.Invoke();
        }
    }
}