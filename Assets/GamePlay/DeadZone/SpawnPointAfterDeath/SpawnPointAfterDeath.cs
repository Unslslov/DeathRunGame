using UnityEngine;

public class SpawnPointAfterDeath : MonoBehaviour
{
    [SerializeField] private DeadZone _deadZone;
    private void OnTriggerEnter(Collider col) 
    {
        if (col.CompareTag("Player"))
        {
            _deadZone.SpawnPoint = transform;
        }
    }
}
