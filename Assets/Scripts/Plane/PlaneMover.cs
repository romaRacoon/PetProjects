using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMover : MonoBehaviour
{
    private const int _template = 0;

    [SerializeField] private Border[] _borders;
    [SerializeField] private float _speed;

    private int _borderIndex = 0;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.isKinematic = true;

        StartMove();
    }

    private IEnumerator Move()
    {
        while (_transform.position != _borders[_borderIndex].gameObject.transform.position)
        {
            var target = _borders[_borderIndex].gameObject.transform.position;
            _transform.position = Vector3.MoveTowards(_transform.position, target, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void StartMove()
    {
        StartCoroutine(Move());
    }

    public void EditBorderIndex()
    {
        if (_borderIndex == _template)
            _borderIndex++;
        else
            _borderIndex--;
    }
}
