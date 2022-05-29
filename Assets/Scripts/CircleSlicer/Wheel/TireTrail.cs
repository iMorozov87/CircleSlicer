using UnityEngine;

public class TireTrail : MonoBehaviour
{
    [SerializeField] private WheelCollision _wheelCollision;
    [SerializeField] private TrailRenderer _tireTrailRenderer;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        _tireTrailRenderer.emitting = _wheelCollision.IsPlatformCollided;       
        _tireTrailRenderer.transform.position = new Vector3(_wheelCollision.CollisionPosition.x + _offset.x,
                                                            _wheelCollision.CollisionPosition.y + _offset.y,
                                                            _wheelCollision.transform.position.z);
    }

    public void Disable()
    {
        _tireTrailRenderer.emitting = false;
        enabled = false;
    }
}
