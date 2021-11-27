using UnityEngine;

namespace Game.Collectables
{
    public class FoodBehaviour : BaseCollectableBehaviour
    {
        protected override void PerformAction(GameObject otherGameObject)
        {
            var healthScript = otherGameObject.GetComponent<SnakeHealth>();
            healthScript.SpawnBodyBlock();
            gameObject.SetActive(false);
            _event.OnOcurred(this); // Dispatches the event, for the subscribed methods be runned
        }
    }
}