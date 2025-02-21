<<<<<<< HEAD
using System;
=======
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
using UnityEngine;

public class SpawnPointAfterDeath : MonoBehaviour
{
<<<<<<< HEAD
    public Action<int> GetNumberPoint;
    public int NumberPoint;
    
    private void OnTriggerEnter(Collider col) 
    {
        GetNumberPoint?.Invoke(NumberPoint);
=======
    [SerializeField] private DeadZone _deadZone;
    private void OnTriggerEnter(Collider col) 
    {
        if (col.CompareTag("Player"))
        {
            _deadZone.SpawnPoint = transform;
        }
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
    }
}
