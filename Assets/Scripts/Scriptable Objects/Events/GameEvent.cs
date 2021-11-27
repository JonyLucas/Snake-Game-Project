using Game.Observer.Listeners;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 55)]
    public class GameEvent : ScriptableObject
    {
        private readonly List<EventListener> _listeners = new List<EventListener>();

        public void Register(EventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void OnOcurred()
        {
            _listeners.ForEach(listener => listener.OnEventOccurs());
        }
    }
}