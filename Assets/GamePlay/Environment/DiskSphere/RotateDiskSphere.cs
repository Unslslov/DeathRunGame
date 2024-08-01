using UnityEngine;

public class RotateDiskSphere : MonoBehaviour
{
    [SerializeField] private Vector3 _offsetRotation;
    private void FixedUpdate() 
    {
        transform.Rotate(_offsetRotation);
    }
}
