using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerControl _playerControl;

    [SerializeField]
    private PlayerControl _player2Control;

    [SerializeField]
    private GameObject _snakePrefab;

    [SerializeField]
    private GameObject _snake2Prefab;

    [SerializeField]
    private Vector3 _initialPlayer1Position;

    [SerializeField]
    private Vector3 _initialPlayer2Position;

    private bool _isGameOver = false;

    public void StartGame(bool isMultiplayer)
    {
        CreatePlayer(true);
        if (isMultiplayer)
        {
            CreatePlayer(false);
        }
    }

    private void CreatePlayer(bool isPlayer1)
    {
        var inputManager = CreateInputManager();
        var prefab = isPlayer1 ? _snakePrefab : _snake2Prefab;
        var position = isPlayer1 ? _initialPlayer1Position : _initialPlayer2Position;
        var control = isPlayer1 ? _playerControl : _player2Control;
        var snake = Instantiate(prefab, position, Quaternion.identity);

        inputManager.GetComponent<InputManager>().SetHeadAndControl(snake, control);
    }

    private GameObject CreateInputManager()
    {
        var inputManager = new GameObject("InputManager");
        inputManager.AddComponent<InputManager>();
        return Instantiate(inputManager, transform);
    }
}