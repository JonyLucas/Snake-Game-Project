using Game.Collectables;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentScore;

        private Text _textComponent;

        private void Start()
        {
            _currentScore = 0;
            _textComponent = GetComponent<Text>();
            UpdateText();
        }

        public void UpdateScore(BaseCollectableBehaviour collactableScript)
        {
            _currentScore += collactableScript.ScoreValue;
            UpdateText();
        }

        public void ResetScore()
        {
            _currentScore = 0;
            UpdateText();
        }

        private void UpdateText()
        {
            _textComponent.text = $"Score: {_currentScore}";
        }
    }
}