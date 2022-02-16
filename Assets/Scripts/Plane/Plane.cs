using UnityEngine;

[RequireComponent(typeof(PlaneBombDropper))]
[RequireComponent(typeof(PlaneMover))]
public class Plane : MonoBehaviour
{
    private const int _template = 1;

    private PlaneMover _planeMover;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _planeMover = GetComponent<PlaneMover>();
    }

    public void ChangeDirection(int borderIndex)
    {
        if (borderIndex == _template)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _planeMover.EditBorderIndex();
    }
}
