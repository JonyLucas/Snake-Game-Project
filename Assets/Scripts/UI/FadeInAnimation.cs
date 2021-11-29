using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class FadeInAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _fadeSpeed;

        private Image _image;

        private void OnEnable()
        {
            _image = GetComponent<Image>();
            _image.color = Color.white;
        }

        private void Update()
        {
            var color = _image.color;
            color.a -= _fadeSpeed;
            _image.color = color;

            if (color.a <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}