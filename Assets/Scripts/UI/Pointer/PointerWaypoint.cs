using UnityEngine;

public class PointerWaypoint : MonoBehaviour
{
    private RectTransform _rectTransform;

    public RectTransform RectTransform => _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
