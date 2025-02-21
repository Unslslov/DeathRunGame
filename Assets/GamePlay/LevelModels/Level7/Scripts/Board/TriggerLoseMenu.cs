using UnityEngine;

public class TriggerLoseMenu : MonoBehaviour
{
    [SerializeField] private LoseGame _loseGameMenu;
    
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            _loseGameMenu.gameObject.SetActive(true);
            Time.timeScale = 0f; // Freeze time

        }
    }
}
