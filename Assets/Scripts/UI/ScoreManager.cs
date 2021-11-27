using Game.Collectables;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;

    private Text _textComponent;

    private void Start()
    {
        _currentScore = 0;
        _textComponent = GetComponent<Text>();
        SetText();
    }

    public void UpdateScore(BaseCollectableBehaviour collactableScript)
    {
        _currentScore += collactableScript.ScoreValue;
        SetText();
    }

    private void SetText()
    {
        _textComponent.text = $"Score: {_currentScore}";
    }
}