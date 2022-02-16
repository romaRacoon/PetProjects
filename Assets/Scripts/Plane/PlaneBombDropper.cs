using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBombDropper : MonoBehaviour
{
    private const int _template = 0;
    private const int _bombsAmount = 3;

    private const float _timeBetweenDrop = 2f;

    [SerializeField] private Bomb _prefab;
    [SerializeField] private DropPoint _dropPoint;

    private List<Bomb> _bombs = new List<Bomb>();

    private void Awake()
    {
        InitializeBombs();
    }

    private void Start()
    {
        StartCoroutine(Drop());
    }

    private void OnEnable()
    {
        SubcribeOnEvent();
    }

    private void OnDisable()
    {
        UnsubscribeFromEvent();
    }

    private IEnumerator Drop()
    {
        while (_bombs.Count > _template)
        {
            yield return new WaitForSecondsRealtime(_timeBetweenDrop);

            var bomb = _bombs[_bombs.Count - 1];
            bomb.gameObject.SetActive(true);
            bomb.gameObject.transform.position = _dropPoint.gameObject.transform.position;

            _bombs.Remove(bomb);
        }
    }

    private void InitializeBombs()
    {
        for (int i = 0; i < _bombsAmount; i++)
        {
            var bomb = Instantiate(_prefab);
            bomb.gameObject.SetActive(false);
            _bombs.Add(bomb);
        }
    }

    private void OnEvent(Bomb bomb)
    {
        _bombs.Add(bomb);
    }

    private void SubcribeOnEvent()
    {
        for (int i = 0; i < _bombs.Count; i++)
        {
            _bombs[i].Clicked += OnEvent;
        }

        for (int i = 0; i < _bombs.Count; i++)
        {
            _bombs[i].Blasted += OnEvent;
        }
    }

    private void UnsubscribeFromEvent()
    {
        for (int i = 0; i < _bombs.Count; i++)
        {
            _bombs[i].Clicked -= OnEvent;
        }

        for (int i = 0; i < _bombs.Count; i++)
        {
            _bombs[i].Blasted -= OnEvent;
        }
    }
}
