using UnityEngine;

public class PlayerMover : Mover
{
    private void FixedUpdate()
    {
        Move(Vector3.forward.normalized);
    }
}
