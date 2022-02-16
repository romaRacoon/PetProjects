using UnityEngine;
using UnityEngine.Events;

public class AmountHousesChecker : MonoBehaviour
{
    private const int _template = 0;

    [SerializeField] private House[] _houses;

    private int _housesAmount;

    public event UnityAction AllHousesDestroyed;

    private void Start()
    {
        _housesAmount = _houses.Length;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _houses.Length; i++)
        {
            _houses[i].Destroyed += OnDestroyed;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _houses.Length; i++)
        {
            _houses[i].Destroyed -= OnDestroyed;
        }
    }

    private void OnDestroyed()
    {
        _housesAmount--;

        if (_housesAmount == _template)
        {
            AllHousesDestroyed?.Invoke();
        }
    }
}
