using UnityEngine;

public class AroundMovement : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _speedRotation = 5f;
    
    void FixedUpdate()
    {
        transform.RotateAround(_point.position, Vector3.left, _speedRotation * Time.deltaTime);
    }
}
