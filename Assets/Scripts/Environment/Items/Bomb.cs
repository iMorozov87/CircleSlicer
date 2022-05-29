using UnityEngine;

public class Bomb : Item
{
    [SerializeField] private ParticleEffects _boomEffects;

    public void Explode()
    {
        _boomEffects.Play(transform.position);       
        gameObject.SetActive(false);
    }
}
