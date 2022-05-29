using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CutItem : MonoBehaviour
{
    [SerializeField] private float _repulsiveForce = 500f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Slice(Vector3 slicePosition)
    {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        Vector3 direction = _rigidbody.transform.position - slicePosition;
        _rigidbody.AddForceAtPosition(direction.normalized * _repulsiveForce, slicePosition);
        StartCoroutine(WaitDisable());
    }

    private IEnumerator WaitDisable()
    {
        float delay = 1f;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }   
}


