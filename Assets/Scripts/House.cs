using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private Sprite _destroyedSprite;

    private SpriteRenderer _spriteRenderer;

    private bool _isDestroyed = false;

    public event UnityAction Destroyed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Bomb>(out Bomb bomb))
        {
            if (_isDestroyed == false)
            {
                _isDestroyed = true;
                _spriteRenderer.sprite = _destroyedSprite;
                Destroyed?.Invoke();
            }
        }
    }
}
