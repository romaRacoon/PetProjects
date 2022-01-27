using UnityEngine;

[RequireComponent(typeof(BrickMover))]
public class Brick : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private Color _idleColor = Color.white;
    private Color _selectedColor = Color.yellow;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _meshRenderer.material.color = _selectedColor;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _meshRenderer.material.color = _idleColor;
        }
    }
}
