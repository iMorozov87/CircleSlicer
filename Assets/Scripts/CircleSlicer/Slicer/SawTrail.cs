using UnityEngine;

public class SawTrail : MonoBehaviour
{
    [SerializeField] private SawCollision _sawCollision;
    [SerializeField] private ParticleSystem _trailEffect;

    private void LateUpdate()
    {
        TryBeginPlying();
        TryStopPlaying();
        _trailEffect.transform.position = GetCurrentPosition();
    }

    public void Disable()
    {
        _trailEffect.Stop();
        enabled = false;
    }
    
   private void TryBeginPlying()
    {
        if (_sawCollision.IsPlatformCollided && _trailEffect.isPlaying == false)
        {
            _trailEffect.Play();
        }
    }
    private void  TryStopPlaying()
    {
        if (_sawCollision.IsPlatformCollided == false)
        {
            _trailEffect.Stop();
        }
    }

    private Vector3 GetCurrentPosition()
    {
        return new Vector3(_sawCollision.CollisionPosition.x, _sawCollision.CollisionPosition.y, _sawCollision.transform.position.z);
    }
}
