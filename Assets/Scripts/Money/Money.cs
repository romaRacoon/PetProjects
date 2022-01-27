using UnityEngine;

public class Money : MonoBehaviour
{
    private const int _cost = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.EarnMoney(_cost);
            gameObject.SetActive(false);
        }
    }
}
