using UnityEngine;

public class SlicerRotator : MonoBehaviour
{
    [SerializeField] private Transform _rotationCentre;

    private float _rotationAngle;
    private float _rotationSpeed = 100;

    private void Update()
    {
        _rotationAngle = GetClampedAngle();
        _rotationCentre.Rotate(new Vector3(_rotationAngle * _rotationSpeed * Time.deltaTime, 0, 0));
    }

    public void SetAngle(float rotationAngle)
    {
        _rotationAngle = rotationAngle;
    }

    private float GetClampedAngle()
    {
        float maxAngle = 90;
        float minAngle = 19;
        float angle = _rotationAngle;

        if (angle == 0 && _rotationCentre.localEulerAngles.x > minAngle && _rotationCentre.localEulerAngles.x < maxAngle)
        {
            angle = -0.5f;
        }
        return angle;
    }
}
