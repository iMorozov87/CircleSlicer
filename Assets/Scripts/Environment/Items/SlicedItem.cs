using UnityEngine;

public class SlicedItem : Item
{
    [SerializeField] private CutItem[] _cutItems;
    [SerializeField] private ParticleEffects _damageEffect;    

    public void Slice(Vector3 slicePosition)
    {
        DeactivateCollider();
        foreach (var cutItem in _cutItems)
        {
            cutItem.Slice(slicePosition);
        }      
        _damageEffect.Play(slicePosition);   
    }    
}
