using UnityEngine;

namespace Game.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Game Object Event", menuName = "Game Object Event", order = 56)]
    public class GameObjectEvent : GenericGameEvent<GameObject>
    {
    }
}