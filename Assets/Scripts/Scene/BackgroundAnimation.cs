using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;

    [SerializeField]
    private float _xLimit = -7;

    [SerializeField]
    private float _yLimit = 7;

    [SerializeField]
    private Sprite _backgroundImage;

    [SerializeField]
    private Sprite _backgroundImageReverse;

    private Sprite _currenteSprite;

    private SpriteRenderer _renderer;

    private readonly Vector2 _moveDirection = new Vector2(-1, 1).normalized;

    private void Start()
    {
        _currenteSprite = _backgroundImage;
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
        if (transform.position.x < _xLimit || transform.position.y > _yLimit)
        {
            transform.position = new Vector3(-_xLimit, -_yLimit, 0);
            //_currenteSprite = _currenteSprite.name == _backgroundImage.name ? _backgroundImageReverse : _backgroundImage;
            //_renderer.sprite = _currenteSprite;
        }
    }
}