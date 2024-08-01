using UnityEngine;

public class PlayerOnThePlatformSecret : MonoBehaviour
{
   [SerializeField] private Transform _platform;
   [SerializeField] private SecretMovement _secretPlatform;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(_platform);

            _secretPlatform.isPlayerOnTheSecretPlatform = true;
        }    
    }

    private void OnTriggerExit(Collider col) 
    {
        col.gameObject.transform.SetParent(null);  
    }
}
