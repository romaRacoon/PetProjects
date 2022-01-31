using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _position;

    private Transform _transform;
    private Vector3 _startPosition;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Bone>(out Bone bone))
        {
            if (bone.GetComponentInParent<Enemy>().IsAlive)
            {
                StopAllCoroutines();
                StartRemoving();

                bone.GetComponentInParent<Enemy>().Die();
                bone.GetComponentInParent<Enemy>().PushBack();
            }
        }
    }

    private IEnumerator Move(Vector3 target)
    {
        while (_transform.position != target)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    public void StartRemoving()
    {
        StartCoroutine(Move(_startPosition));
    }

    public void StartMove(Vector3 target)
    {
        StartCoroutine(Move(target));
    }

    public void SetStartPosition()
    {
        _startPosition = _transform.position;
    }

    public void ReturnToPosition()
    {
        _transform.position = _position.transform.position;
    }
}
