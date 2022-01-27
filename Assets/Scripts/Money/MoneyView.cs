using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private FinishPlatform[] _finishPlatforms;
    [SerializeField] private Player _player;

    private TMP_Text _balance;

    private void Start()
    {
        _balance = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.Earned += OnEarned;

        SignUpEvent();
    }

    private void OnDisable()
    {
        _player.Earned -= OnEarned;

        UnsubscribedEvent();
    }

    private void OnEarned(int balance)
    {
        _balance.SetText(balance.ToString());
    }

    private void SignUpEvent()
    {
        for (int i = 0; i < _finishPlatforms.Length; i++)
        {
            _finishPlatforms[i].Finished += OnFinished;
        }
    }

    private void UnsubscribedEvent()
    {
        for (int i = 0; i < _finishPlatforms.Length; i++)
        {
            _finishPlatforms[i].Finished -= OnFinished;
        }
    }

    private void OnFinished(int multiplier)
    {
        int finishBalance = int.Parse(_balance.text) * multiplier;
        _balance.SetText(finishBalance.ToString());
    }
}
