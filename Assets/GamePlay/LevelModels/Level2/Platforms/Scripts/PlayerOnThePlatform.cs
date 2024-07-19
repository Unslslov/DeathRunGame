using UnityEngine;

public class PlayerOnThePlatform : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(_platform);
        }    
    }

    private void OnTriggerExit(Collider col) 
    {
        col.gameObject.transform.SetParent(null);    
    }
}
