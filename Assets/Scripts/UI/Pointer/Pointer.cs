using System.Collections;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private const int _template = 0;

    [SerializeField] private PointerWaypoint[] _waypoints;

    private int _waypointIndex;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        StartCoroutine(Relocate());
    }

    private IEnumerator Relocate()
    {
        while (true)
        {
            _waypointIndex = Random.Range(_template, _waypoints.Length);
            _rectTransform.position = _waypoints[_waypointIndex].RectTransform.position;

            yield return new WaitForSeconds(1f);
        }
    }
}
