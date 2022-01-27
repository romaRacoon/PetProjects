using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform _transform;

    public Rigidbody Rigidbody => _rigidbody;
    public Transform Transform => _transform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        _rigidbody.freezeRotation = true;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(_transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}
