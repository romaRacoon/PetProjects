using UnityEngine;
using UnityEngine.Events;

public class FinishPlatform : MonoBehaviour
{
    private const int _templateConst = 1;

    [SerializeField] private int _colorsIndex;

    private Color[] _colors = { Color.yellow, Color.red, Color.blue, Color.green };
    private MeshRenderer _meshRenderer;

    public event UnityAction<int> Finished;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        InitializedColor();
    }

    private void InitializedColor()
    {
        _meshRenderer.material.color = _colors[_colorsIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Mover>().enabled = false;
            player.Dance();
            Finished?.Invoke(_colorsIndex + _templateConst);
        }
    }
}
