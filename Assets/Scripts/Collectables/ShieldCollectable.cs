using Game.Player;
using UnityEngine;

namespace Game.Collectables
{
    public class ShieldCollectable : BaseCollectableBehaviour
    {
        protected override void PerformAction(GameObject otherGameObject)
        {
            var tag = otherGameObject.tag;
            if (otherGameObject.CompareTag("SnakeHead"))
            {
                tag = otherGameObject.transform.parent.tag;
            }

            if (tag == "Player")
            {
                var healthScript = otherGameObject.GetComponent<SnakeHealth>();
                healthScript.AcquiredShield();
                _event.OnOcurred(this); // Dispatches the event, for the subscribed methods be runned
            }

            gameObject.SetActive(false);
        }
    }
}