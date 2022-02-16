using UnityEngine;

public class Victory : MonoBehaviour
{
    private const float _template = 0f;

    [SerializeField] private AmountHousesChecker _amountHousesChecker;
    [SerializeField] private GameObject _winPanel;

    private void Start()
    {
        _winPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _amountHousesChecker.AllHousesDestroyed += OnAllHousesDestroyed;
    }

    private void OnDisable()
    {
        _amountHousesChecker.AllHousesDestroyed -= OnAllHousesDestroyed;
    }

    private void OnAllHousesDestroyed()
    {
        _winPanel.SetActive(true);
        Time.timeScale = _template;
    }
}
