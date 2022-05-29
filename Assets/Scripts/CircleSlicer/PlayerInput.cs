using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private SlicerRotator _slicerRotator;

    private const string VerticalAxisName = "Vertical";

    private void Update()
    {
        float verticalInput = Input.GetAxis(VerticalAxisName);
        _slicerRotator.SetAngle(verticalInput);
    }
}
