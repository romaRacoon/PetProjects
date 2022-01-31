using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public event UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Finished?.Invoke();
        }
    }
}
