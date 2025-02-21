using UnityEngine;

public class ActivateEndLevelTrigger : MonoBehaviour
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
