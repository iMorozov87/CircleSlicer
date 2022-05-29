using UnityEngine;
using DG.Tweening;

public class WheelTracker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Slicer _target;

    private Vector3 _offset;
    private float _speed = 0.9f;

    private void Awake()
    {
        _offset = transform.position- _target.transform.position;
    }

    private void OnEnable()
    {
        _target.ShakingCollided += OnShakingCollided;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _offset, _speed);
    }

    private void OnDisable()
    {
        _target.ShakingCollided -= OnShakingCollided;
    }

    public void MoveToFinishPosition(Vector3 position, float durationFinishAction)
    {
        enabled = false;
        transform.DOMove(position, durationFinishAction);
    }

    private void OnShakingCollided()
    {
        ShakeCamera();
    }

    private void ShakeCamera()
    {
        float amplitude = 0.1f;
        float duration = 0.08f;
        Vector3[] path = new Vector3[] {_camera.transform.localPosition + Vector3.up * amplitude , Vector3.zero};
        _camera.transform.DOLocalPath(path, duration, PathType.Linear).SetEase(Ease.Linear);
    }
}
