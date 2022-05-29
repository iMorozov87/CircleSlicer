using UnityEngine;

public class WheelCollision : CollisionDetecter
{
    [SerializeField] private Collider _whellCollider;

    private void OnCollisionStay(Collision collision)
    {
        CheckCollision(_whellCollider, collision, TryPlatformDetect);
    }

    private void OnCollisionExit(Collision collision)
    {       
        TryPlatformEscaped(collision);
    }
}
