using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private int _index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Plane>(out Plane plane))
        {
            plane.ChangeDirection(_index);
        }
    }
}
