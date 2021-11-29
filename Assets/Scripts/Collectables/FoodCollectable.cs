using Game.Player;
using UnityEngine;

namespace Game.Collectables
{
    public class FoodCollectable : BaseCollectableBehaviour
    {
        [SerializeField]
        private int _scoreValue;

        public int ScoreValue
        { get { return _scoreValue; } }

        protected override void PerformAction(GameObject otherGameObject)
        {
            var healthScript = otherGameObject.GetComponent<SnakeHealth>();
            healthScript.SpawnBodyBlock();
            gameObject.SetActive(false);
            _event.OnOcurred(this); // Dispatches the event, for the subscribed methods be runned
        }
    }
}