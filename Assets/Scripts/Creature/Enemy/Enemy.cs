using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const float _template = 0.5f;

    private readonly StringBuilder _run = new StringBuilder("Run");
    private readonly StringBuilder _attack = new StringBuilder("Attack");

    [SerializeField] private float _speed;

    private GameObject _target;
    private Animator _animator;
    private Transform _transform;
    private EnemyRepulsor _enemyRepulsor;

    private bool _isAlive = true;

    private Rigidbody[] _rigidbodies;

    public bool IsAlive => _isAlive;

    public event UnityAction Attacked;
    public event UnityAction Died;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _enemyRepulsor = GetComponent<EnemyRepulsor>();

        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        _enemyRepulsor.enabled = false;

        AddBone();
        DisableRigidbodies();
    }

    private IEnumerator GoTo()
    {
        while (_transform.position != _target.gameObject.transform.position)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target.gameObject.transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _animator.Play(_attack.ToString());

        yield return new WaitForSeconds(_template);

        Attacked?.Invoke();
    }

    private void DisableRigidbodies()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = true;
        }
    }

    private void EnableRigidbodies()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }

    private void AddBone()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].gameObject.AddComponent<Bone>();
        }
    }

    private void StopRunning()
    {
        _animator.enabled = false;
        StopAllCoroutines();
    }

    public void Die()
    {
        _isAlive = false;
        StopRunning();
        EnableRigidbodies();
        Died?.Invoke();
    }

    public void StartGoTo(GameObject target)
    {
        _target = target;

        _animator.Play(_run.ToString());
        StartCoroutine(GoTo());
    }

    public void PushBack()
    {
        _enemyRepulsor.EnableRigidbody();
        _enemyRepulsor.enabled = true;
    }
}
