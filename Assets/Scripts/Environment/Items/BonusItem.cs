
public class BonusItem : Item
{
    public void Use()
    {
        DeactivateCollider();      
        gameObject.SetActive(false);
    }    
}
