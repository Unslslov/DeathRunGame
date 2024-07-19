using UnityEngine;

public class AlwaysRotating : MonoBehaviour
{
    private void FixedUpdate() 
    {
        transform.Rotate(0.1f, 0f, 0f, Space.Self);
    }
}
