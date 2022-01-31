using UnityEngine;

public class InputDetection : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit raycastHit))
            {
                if(raycastHit.collider.gameObject.TryGetComponent<Bone>(out Bone bone))
                {
                    _player.StartHit(raycastHit.point);
                }
            }
        }
    }
}
