using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;
    
    void Update()
    {
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
    }
}
