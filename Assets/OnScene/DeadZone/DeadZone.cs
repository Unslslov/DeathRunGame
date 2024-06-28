using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform SpawnPoint; 
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterController>().enabled = false;
            col.gameObject.transform.position = SpawnPoint.position;
            
            StartCoroutine(ReturnCharacterController(col.gameObject));
        }    
    }
    private IEnumerator ReturnCharacterController(GameObject player)
    {
        yield return  new WaitForSeconds(1f);

        player.GetComponent<CharacterController>().enabled = true;
    }
}
