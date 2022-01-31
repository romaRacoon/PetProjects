using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//коллайдер врага
public class BLA : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Hand>(out Hand hand))
        {
            hand.StopAllCoroutines();
            hand.StartRemoving();
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<Hand>(out Hand hand))
    //    {
    //        Debug.Log(1);
    //        hand.RemoveToStartPosition();
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Hand>(out Hand hand))
    //    {
    //        Debug.Log(1);
    //        hand.RemoveToStartPosition();
    //    }
    //}
}
