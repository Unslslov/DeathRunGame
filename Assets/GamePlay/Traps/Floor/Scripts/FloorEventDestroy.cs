using UnityEngine;

public class FloorEventDestroy : MonoBehaviour
{
    public void SetRigidBodyCollider()
    {
        gameObject.AddComponent<Rigidbody>();
    }
}
