using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public event UnityAction<Bomb> Clicked;
    public event UnityAction<Bomb> Blasted;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<House>(out House house))
        {
            Blasted?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void Initialize()
    {
        _rigidbody.gravityScale = Random.Range(1, 3);
    }
}
