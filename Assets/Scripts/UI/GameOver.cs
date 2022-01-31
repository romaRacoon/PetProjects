using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Text _lossText;

    private void Start()
    {
        _lossText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Attacked += OnAttacked;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Attacked -= OnAttacked;
        }
    }

    private void OnAttacked()
    {
        _lossText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
