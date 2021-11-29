using Game.Player.PlayerInput;
using Game.ScriptableObjects;
using Game.Spawner;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    private void CreatePlayer(bool isPlayer1)
    {
        var inputManager = CreateInputManager();
        var prefab = isPlayer1 ? _snakePrefab : _snake2Prefab;
        var control = isPlayer1 ? _playerControl : _player2Control;
        var snake = Instantiate(prefab);
        snake.name = isPlayer1 ? "Player 1" : "Player 2";

        inputManager.GetComponent<InputManager>().SetHeadAndControl(snake, control);
    }

    private GameObject CreateInputManager()
    {
        var inputManager = new GameObject("InputManager");
        inputManager.AddComponent<InputManager>();
        return Instantiate(inputManager, transform);
    }

    public void GameOver()
    {
        // Destroy the input managers.
        DestroyInputManagers();

        // Disables the collectables and the spawner
        ActivateSpawner(false);
    }

    private void DestroyInputManagers()
    {
        var components = transform.GetComponentsInChildren<InputManager>();
        var count = components.Count();
        for (int i = 0; i < count; i++)
        {
            Destroy(components[i].gameObject);
        }
    }

    private void ActivateSpawner(bool activate)
    {
        _spawner.GetComponents<BaseSpawner>()
            .ToList()
            .ForEach(spwaner => spwaner.SetSpawnCondition(activate));
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}