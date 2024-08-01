using UnityEngine;

public class AlwaysElevatorRotating : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;

     private void FixedUpdate() 
    {
        transform.Rotate(0f, 0f, _speed, Space.Self);
    }
}

