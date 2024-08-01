using System.Collections;
using UnityEngine;
using Player;

public class JumperTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbPlayer;
    [SerializeField] private Vector3 _force = Vector3.zero;
    [SerializeField] private Movement _playerMovement;


    public void SetRigidBodyForJumper(ref Rigidbody rigidbody)
    {
        if(_rbPlayer == null)
        {
            _rbPlayer = rigidbody;
            _playerMovement = _rbPlayer.GetComponent<Movement>();
        }   
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            _playerMovement.enabled = false;
            _rbPlayer.velocity = Vector3.zero;
            _rbPlayer.velocity = new Vector3(_rbPlayer.velocity.x + _force.x, _rbPlayer.velocity.y + _force.y, _rbPlayer.velocity.z + _force.z);

            StartCoroutine(ActivatePlayerMovement());
        }
    }
    IEnumerator ActivatePlayerMovement()
    {
        yield return new WaitForSeconds(0.5f);
        _playerMovement.enabled = true;
    }
}
