using UnityEngine;

public abstract  class Item : MonoBehaviour
{
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    protected void DeactivateCollider()
    {
        _collider.enabled = false;
    }    
}
