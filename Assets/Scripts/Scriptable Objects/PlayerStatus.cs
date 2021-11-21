using UnityEngine;

public class PlayerStatus : ScriptableObject
{
    public int Score { get; set; } = 0;
    public GameObject[] PowerUps { get; set; }
}