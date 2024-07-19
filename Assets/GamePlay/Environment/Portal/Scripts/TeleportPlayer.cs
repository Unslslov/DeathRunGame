using UnityEngine;

namespace FakeTeleport
{
public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform _point;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.transform.position = _point.transform.position;

        }     
    }
}
}