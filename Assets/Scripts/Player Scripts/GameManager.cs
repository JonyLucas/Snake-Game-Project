using Game.Player.PlayerInput;
using Game.ScriptableObjects;
using Game.Spawner;
using System.Linq;
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
    private GameObject _spawner;

    public void StartGame(bool isMultiplayer)
    {
        CreatePlayer(true);
        if (isMultiplayer)
        {
            CreatePlayer(false);
        }
        ActivateSpawner(true);
    }

    private void CreatePlayer(bool isPlayer1)
    {
        var inputManager = CreateInputManager();
        var prefab = isPlayer1 ? _snakePrefab : _snake2Prefab;
        var control = isPlayer1 ? _playerControl : _player2Control;
        var snake = Instantiate(prefab);

        inputManager.GetComponent<InputManager>().SetHeadAndControl(snake, control);
    }

    private GameObject CreateInputManager()
    {
        var inputManager = new GameObject("InputManager");
        inputManager.AddComponent<InputManager>();
        return Instantiate(inputManager, transform);
    }

    private void ActivateSpawner(bool activate)
    {
        _spawner.GetComponents<BaseSpawner>()
            .ToList()
            .ForEach(spwaner => spwaner.SetSpawnCondition(activate));
    }

    public void GameOver()
    {
        // Disables the collectables and the spawner
        ActivateSpawner(false);
    }
}