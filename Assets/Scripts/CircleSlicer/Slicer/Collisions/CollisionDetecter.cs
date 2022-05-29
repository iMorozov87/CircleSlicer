using System;
using System.Linq;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    private bool _isPlatformCollided = false;
    private Vector3 _collisionPosition = Vector3.zero;

    public bool IsPlatformCollided => _isPlatformCollided;
    public Vector3 CollisionPosition => _collisionPosition;

    protected void CheckCollision(Collider targetCollider, Collision collision, Action<ContactPoint> TryDetect)
    {
        int maxContactPoint = 16;
        ContactPoint[] contacts = new ContactPoint[maxContactPoint];
        collision.GetContacts(contacts);
        ContactPoint targetContact = contacts.FirstOrDefault(contact => contact.thisCollider == targetCollider);
        if (targetContact.Equals(default(ContactPoint)))
            return;
        TryDetect.Invoke(targetContact);
    }

    protected void TryPlatformDetect(ContactPoint targetContact)
    {
        if (targetContact.otherCollider.TryGetComponent(out Platform platform))
        {
            _collisionPosition = targetContact.point;
            _isPlatformCollided = true;
        }
    }

    protected void TryPlatformEscaped(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isPlatformCollided = false;
        }
    }
}
