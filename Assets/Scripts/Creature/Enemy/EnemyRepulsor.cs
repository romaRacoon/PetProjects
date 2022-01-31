using UnityEngine;

public class EnemyRepulsor : MonoBehaviour
{
    private const float _dragTemplateConst = 1f;
    private const float _pushPowerConst = 50f;

    private Rigidbody[] _rigidbodies;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = true;
            _rigidbodies[i].drag = _dragTemplateConst;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].AddForce(-transform.forward * _pushPowerConst);
        }
    }

    public void EnableRigidbody()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
