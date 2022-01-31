using UnityEngine;

public class Battlefield : MonoBehaviour
{
    private int _enemiesAmount = 0;
    private Player _player;
  
    private Enemy[] _enemies;

    private void Awake()
    {
        _enemies = GetComponentsInChildren<Enemy>();
    }

    private void Start()
    {
        _enemiesAmount = _enemies.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _player = player;
                _player.StopMove();
                _player.SetStartPositionForHands();
                _enemies[i].StartGoTo(_player.EnemyTarget);
            }
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Died += OnDied;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Died -= OnDied;
        }
    }

    private void OnDied()
    {
        _enemiesAmount--;

        if (_enemiesAmount == 0)
        {
            _player.ReturnHandsToPosition();
            _player.StartMove();
        }
    }
}
