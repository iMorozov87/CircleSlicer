using System;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private WheelTracker _wheelTracker;
    [SerializeField] private WheelMover _wheelMover;
    [SerializeField] private WhellRotator[] _whellRotators;
    [SerializeField] private TireTrail _tireTrail;
    [SerializeField] private ParticleEffects _particleEffects;
    [SerializeField] private Transform _wheelTarget;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _particlesTransform;

    private void OnEnable()
    {
        _finishLine.Reached += OnFinishReached;
    }

    private void OnDisable()
    {
        _finishLine.Reached -= OnFinishReached;
    }

    private void OnFinishReached()
    {
        float durationFinishAction = 0.5f;
        PlayFinishActions(durationFinishAction);
    }

    private void PlayFinishActions(float durationFinishAction)
    {
        _wheelMover.MoveToFinishPosition(_wheelTarget, durationFinishAction);
        _wheelTracker.MoveToFinishPosition(_cameraTarget.position, durationFinishAction);
        _particleEffects.PlayAsChild(_particlesTransform);
        _tireTrail.Disable();
        StopRotation(_whellRotators);        
    }

    private void StopRotation(WhellRotator[] _whellRotators)
    {
        foreach (var rotator in _whellRotators)
        {
            rotator.enabled = false;
        }
    }
}
