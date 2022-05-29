using UnityEngine;
using UnityEngine.Events;

public class Slicer : MonoBehaviour
{ 
    [SerializeField] private SlicerEnchancer _slicerUpgrader;
    [SerializeField] private SawCollision _slicerCollision;
  
    public event UnityAction ShakingCollided;

    private void OnEnable()
    {
        _slicerCollision.ItemCollided += OnSlicerCollided;
    }

    private void OnDisablr()
    {
        _slicerCollision.ItemCollided -= OnSlicerCollided;
    }

    private void OnSlicerCollided(Item item, Vector3 slicePosition)
    {
        RouteAction(item, slicePosition);
    } 

    private void RouteAction(Item item, Vector3 slicePosition)
    {
        switch (item)
        {
            case SlicedItem slicedItem:
                slicedItem.Slice(slicePosition);
                if (slicedItem is ShakeCallingItem)
                {
                    ShakingCollided?.Invoke();
                }
                break;
            case BonusItem bonus:
                Upgrade();
                bonus.Use();
                break;
            case Bomb bomb:
                bomb.Explode();
                break;
        };
    }

    private void Upgrade()
    {
        _slicerUpgrader.ActivateSawBoost();
    } 
}
