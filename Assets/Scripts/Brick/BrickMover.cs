using UnityEngine;

public class BrickMover : Mover
{
    [SerializeField] private ClickDetection _clickDetection;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _clickDetection._clicked += OnClicked;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _clickDetection._clicked -= OnClicked;
        }
    }

    private void OnClicked()
    {
        Move(Vector3.up.normalized);
    }
}
