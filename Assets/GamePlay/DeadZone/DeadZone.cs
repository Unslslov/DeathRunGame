using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform _spawns; 
    [SerializeField] private SpawnPointCollection _spawnPointCollection;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.transform.position = _spawns.GetChild(_spawnPointCollection._currentActivePoint).transform.position;
        }    
    }
}
