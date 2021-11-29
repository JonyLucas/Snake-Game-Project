using Game.Collectables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ShowIconOnEvent : MonoBehaviour
    {
        private Image _imageComponent;

        private void Start()
        {
            _imageComponent = GetComponent<Image>();
        }

        public void EnableIcon(BaseCollectableBehaviour collactableScript)
        {
            if (collactableScript.GetType() == typeof(ShieldCollectable))
            {
                _imageComponent.enabled = true;
            }
        }
    }
}