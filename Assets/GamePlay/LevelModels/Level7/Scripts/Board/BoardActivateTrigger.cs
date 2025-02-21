using UnityEngine;

public class BoardActivateTrigger : MonoBehaviour
{
    [SerializeField] private BoardMoving _board;
    [SerializeField] private Transform _platform;
    [SerializeField] private Vector3 _playerScale;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            _playerScale = col.gameObject.transform.localScale;
            col.gameObject.transform.SetParent(_platform);

            StartCoroutine(_board.MoveAlongPath());
        }    
    }

    private void OnTriggerExit(Collider col) 
    {
        col.gameObject.transform.SetParent(null);
        col.gameObject.transform.localScale = _playerScale;
    }
}
