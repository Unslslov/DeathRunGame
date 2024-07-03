using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnderStone : MonoBehaviour
{
     public List<ActivateOverPlayer> floors;
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            foreach(var floor in floors)
                floor.SetRigidBodyCollider();
        }
    }
}
