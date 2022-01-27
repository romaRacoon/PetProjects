using UnityEngine;
using UnityEngine.Events;
using System.Text;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const float _minVelocityValueConst = 0f;

    private StringBuilder _run = new StringBuilder("Run");
    private StringBuilder _falling = new StringBuilder("Falling");
    private StringBuilder _dance = new StringBuilder("Dance");

    private Animator _animator;
    private Mover _mover;
    private int _moneyAmount = 0;

    public event UnityAction<int> Earned;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();

        _animator.Play(_run.ToString());
    }

    private void Update()
    {
        if (_mover.Rigidbody.velocity.y < _minVelocityValueConst)
        {
            _animator.Play(_falling.ToString());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Brick>(out Brick brick))
        {
            _animator.Play(_run.ToString());
        }
    }

    public void EarnMoney(int boost)
    {
        _moneyAmount += boost;
        Earned?.Invoke(_moneyAmount);
    }

    public void Dance()
    {
        _animator.Play(_dance.ToString());
    }
}
