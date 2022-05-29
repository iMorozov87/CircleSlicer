using DG.Tweening;
using System;
using UnityEngine;

public class WheelMover : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 15;
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed;
    private float _upgradedSpeed = 23;
    private float _velocityOffset = 1f;

    private void Awake()
    {
        SetSpeedAsDefault();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_speed, _rigidbody.velocity.y - _velocityOffset, 0);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }


    public void SetSpeedAsDefault()
    {
        _speed = _defaultSpeed;
    }

    public void SetSpeedAsUpgraded()
    {
        _speed = _upgradedSpeed;
    }

    public void MoveToFinishPosition(Transform target, float durationFinishAction)
    {
        enabled = false;
        transform.DOMove(target.position, durationFinishAction);
        transform.DORotate(target.rotation.eulerAngles, durationFinishAction);
        transform.DOScale(target.localScale, durationFinishAction);
    }
}
