using System.Collections;
using UnityEngine;

public class SlicerEnchancer : MonoBehaviour
{
    [SerializeField] private ForcedSaw[] _forcedSaws;
    [SerializeField] private ParticleEffects _particleEffects;
    [SerializeField] private WheelMover _wheelMover;
    [SerializeField] private SawTrail _sawTrail;

    private float _enchancedTime = 4f;

    private void OnEnable()
    {
        foreach (var saw in _forcedSaws)
        {
            saw.TargertReached += OnSawTargetReached;
        }
    }

    private void OnDisable()
    {
        foreach (var saw in _forcedSaws)
        {
            saw.TargertReached -= OnSawTargetReached;
        }
    }

    public void ActivateSawBoost()
    {
        foreach (var saw in _forcedSaws)
        {
            saw.Activate();
        }
        _sawTrail.enabled = true;
        _wheelMover.SetSpeedAsUpgraded();
        StartCoroutine(WaitDeactivateSaws());
    }

    private IEnumerator WaitDeactivateSaws()
    {
        yield return new WaitForSeconds(_enchancedTime);
        foreach (var saw in _forcedSaws)
        {
            saw.Deactivate();
        }
        _wheelMover.SetSpeedAsDefault();
        _sawTrail.Disable();
    }
    private void OnSawTargetReached()
    {
        _particleEffects.PlayAsChild(transform);
    }
}
