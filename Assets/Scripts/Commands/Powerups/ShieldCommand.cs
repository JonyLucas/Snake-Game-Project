using Game.Player;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Commands.Powerups
{
    [Serializable]
    public class ShieldCommand : BaseCommand
    {
        private GameObject _imageIcon;

        public override void Execute(GameObject gameObject)
        {
            var healthScript = gameObject.GetComponent<SnakeHealth>();
            if (healthScript != null)
            {
                healthScript.EnableShield();
            }

            // Disables the icon
            if (_imageIcon == null)
            {
                _imageIcon = GameObject.Find("Shield Icon"); // Temporary Solution, not ideal search by the name
            }

            _imageIcon.GetComponent<Image>().enabled = false;
        }
    }
}