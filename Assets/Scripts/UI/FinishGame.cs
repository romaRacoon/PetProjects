using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    private const float _template = 0f;

    [SerializeField] private Waypoint _waypoint;
    [SerializeField] private Text _winText;

    private void Start()
    {
        _winText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _waypoint.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _waypoint.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        _winText.gameObject.SetActive(true);
        Time.timeScale = _template;
    }
}
