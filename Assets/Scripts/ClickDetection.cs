using UnityEngine;
using UnityEngine.Events;

public class ClickDetection : MonoBehaviour
{
    public event UnityAction _clicked;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _clicked?.Invoke();
        }
    }
}
