using UnityEngine;

public class WhellRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _rotationAngle  = new Vector3(20, 0, 0);

    private void Update()
    {
        _target.Rotate(_rotationAngle * Time.deltaTime);
    }
}
