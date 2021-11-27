using UnityEngine;

namespace Game.Collectables
{
    public class FoodBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SnakeHead"))
            {
                var healthScript = collision.GetComponent<SnakeHealth>();
                healthScript.SpawnBodyBlock();
                gameObject.SetActive(false);
            }
        }
    }
}