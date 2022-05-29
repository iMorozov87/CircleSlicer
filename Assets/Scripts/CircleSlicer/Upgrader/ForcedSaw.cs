using UnityEngine;
using UnityEngine.Events;

public class ForcedSaw : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10f;

    public event UnityAction TargertReached;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        if(transform.position == _target.position)
        {
            TargertReached?.Invoke();
            enabled = false;
        }
    }

    public void Activate()
    {
       gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
