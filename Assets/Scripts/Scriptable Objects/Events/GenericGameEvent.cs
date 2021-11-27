using Game.Observer.Listeners;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects.Events
{
    public class GenericGameEvent<T> : ScriptableObject where T : class
    {
        private readonly List<GenericEventListener<T>> _listeners = new List<GenericEventListener<T>>();

        public void Register(GenericEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(GenericEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }

        public void OnOcurred(T monoBehaviouScript)
        {
            _listeners.ForEach(listener => listener.OnEventOccurs(monoBehaviouScript));
        }
    }
}