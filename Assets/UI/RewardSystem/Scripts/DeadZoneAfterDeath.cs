using UnityEngine;

public class DeadZoneAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject _EndLevelWindow;
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            _EndLevelWindow.SetActive(true);
        }
    }
}
