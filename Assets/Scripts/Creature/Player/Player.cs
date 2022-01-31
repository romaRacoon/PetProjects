using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTarget;
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;

    private float _rotationSpeed = 5f;
    private int _handsIndex = 0;
    private int _waypointIndex = 0;

    private Transform _transform;

    private Hand[] _hands;

    public GameObject EnemyTarget => _enemyTarget;

    private void Start()
    {
        _hands = GetComponentsInChildren<Hand>();
        _transform = GetComponent<Transform>();

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_transform.position != _waypoints[_waypointIndex].gameObject.transform.position)
        {
            RotateTo(_waypoints[_waypointIndex].gameObject.transform);

            _transform.position = Vector3.MoveTowards(_transform.position, _waypoints[_waypointIndex].gameObject.transform.position, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void RotateTo(Transform target)
    {
        Vector3 direction = target.position - _transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    public void StartHit(Vector3 target)
    {
        if (_handsIndex == 0)
        {
            _hands[_handsIndex].StartMove(target);
            _handsIndex++;
        }
        else
        {
            _hands[_handsIndex].StartMove(target);
            _handsIndex--;
        }
    }

    public void StopMove()
    {
        StopAllCoroutines();
    }

    public void SetStartPositionForHands()
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            _hands[i].SetStartPosition();
        }
    }

    public void IncreaseWaypointIndex()
    {
        _waypointIndex++;
    }

    public void StartMove()
    {
        StartCoroutine(Move());
    }

    public void ReturnHandsToPosition()
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            _hands[i].StopAllCoroutines();
            _hands[i].ReturnToPosition();
        }
    }
}
