using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public event UnityAction Reached;
    private void OnTriggerExit(Collider other)
    {
      if(other.TryGetComponent(out Wheel wheel))
        {
            Reached?.Invoke();            
        }
    }
}
