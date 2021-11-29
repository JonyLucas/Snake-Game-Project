using Game.ScriptableObjects.Events;
using UnityEngine;

namespace Game.Collectables
{
    public abstract class BaseCollectableBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected CollectableEvent _event;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SnakeHead"))
            {
                PerformAction(collision.gameObject);
            }
        }

        protected abstract void PerformAction(GameObject otherGameObject);
    }
}