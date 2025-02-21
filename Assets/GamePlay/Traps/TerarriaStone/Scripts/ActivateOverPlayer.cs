using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOverPlayer : MonoBehaviour
{
    public void SetRigidBodyCollider()
    {
        gameObject.AddComponent<Rigidbody>();
    }
}
