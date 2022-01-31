using UnityEngine;
using UnityEngine.Events;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool _isFinished = false;

    public event UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (_isFinished)
            {
                Finished?.Invoke();
            }
            else
            {
                player.StopAllCoroutines();
                player.IncreaseWaypointIndex();
                player.StartMove();
            }
        }
    }
}
