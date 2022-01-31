using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player
public class Test : MonoBehaviour
{
    private Hand[] _hands;
    private int _handsIndex = 0;

    private void Start()
    {
        _hands = GetComponentsInChildren<Hand>();
    }

    public void StartHit(Vector3 target)
    {
        if (_handsIndex == 0)
        {
            _hands[_handsIndex].StartMove(target);
            _handsIndex++;
        }
        else
        {
            _hands[_handsIndex].StartMove(target);
            _handsIndex--;
        }
    }
}
