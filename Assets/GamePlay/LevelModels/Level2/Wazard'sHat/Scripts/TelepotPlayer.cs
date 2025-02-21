using UnityEngine;

public class TelepotPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbPlayer;
    [SerializeField] private Transform _teleportToPoint;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            _rbPlayer = col.GetComponent<Rigidbody>();

            col.gameObject.transform.rotation = 
                Quaternion.Euler(col.gameObject.transform.rotation.x, 270f, col.gameObject.transform.rotation.z);
            
            col.gameObject.transform.position = _teleportToPoint.position;
            _rbPlayer.velocity = new Vector3(200f, _rbPlayer.velocity.y, _rbPlayer.velocity.z);

        }        
    }
}
