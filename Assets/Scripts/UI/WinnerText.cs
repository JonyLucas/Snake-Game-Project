using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class WinnerText : MonoBehaviour
    {
        // The object received is the loser (which one was destroyed).
        public void WriteWinner(GameObject player)
        {
            var winnerName = player.transform.parent.name == "Player 1" ? "Player 2" : "Player 1";
            var textComponent = GetComponent<Text>();
            textComponent.text = $"{winnerName} is the Winner!";
        }
    }
}