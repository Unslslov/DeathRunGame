using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
   [SerializeField] private Transform _platform;
   [SerializeField] private ElevatorMovement _elevator;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(_platform);

            _elevator.isPlayerOnTheSecretPlatform = true;
        }    
    }

    private void OnTriggerExit(Collider col) 
    {
        col.gameObject.transform.SetParent(null);  
    }

}
