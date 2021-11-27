using Game.Collectables;
using UnityEngine;

namespace Game.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Collectable Event", menuName = "Collectable Event", order = 56)]
    public class CollectableEvent : GenericGameEvent<BaseCollectableBehaviour>
    {
    }
}