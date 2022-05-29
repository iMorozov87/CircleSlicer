using UnityEngine;
using UnityEngine.Events;

public class SawCollision : CollisionDetecter
{
    [SerializeField] private Collider _sawCollider;

    public event UnityAction<Item, Vector3> ItemCollided;
    public event UnityAction<Vector3> PlatfomCollided;
    public event UnityAction PlatfomLossed;

    private void OnCollisionEnter(Collision collision)
    {
        CheckCollision(_sawCollider, collision, TryItemDetect);
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckCollision(_sawCollider, collision, TryPlatformDetect);      
    }

    private void OnCollisionExit(Collision collision)
    {
        TryPlatformEscaped(collision);       
    }

    private void TryItemDetect(ContactPoint targetContact)
    {
        if (targetContact.otherCollider.TryGetComponent(out Item item))
        {
            ItemCollided?.Invoke(item, targetContact.point);
        }
    }        
}
