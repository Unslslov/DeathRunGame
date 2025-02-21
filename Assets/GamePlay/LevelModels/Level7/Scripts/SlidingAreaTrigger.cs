using Player;
using UnityEngine;

public class SlidingAreaTrigger : MonoBehaviour
{
    [SerializeField] private Sliding _slidingPlayer;
    [SerializeField] private Movement _movementPlayer;


    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            _slidingPlayer = col.GetComponent<Sliding>();
            _movementPlayer = col.GetComponent<Movement>();

            _movementPlayer.enabled = false;
            _slidingPlayer.enabled = true;

            _slidingPlayer.StartSliding();
        }
    }

    private void OnTriggerExit(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            _slidingPlayer.EndSliding();
    
            _movementPlayer.enabled = true;
        }
    }
}
