using System;
using UnityEngine;

public class SpawnPointAfterDeath : MonoBehaviour
{
    public Action<int> GetNumberPoint;
    public int NumberPoint;
    
    private void OnTriggerEnter(Collider col) 
    {
        GetNumberPoint?.Invoke(NumberPoint);
    }
}
