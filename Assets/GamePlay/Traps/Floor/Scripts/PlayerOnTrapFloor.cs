using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTrapFloor : MonoBehaviour
{
    public List<FloorEventDestroy> floors;
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            foreach(var floor in floors)
                floor.SetRigidBodyCollider();
        }
    }
}
