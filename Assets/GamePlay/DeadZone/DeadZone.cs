<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
using UnityEngine;

public class DeadZone : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Transform _spawns; 
    [SerializeField] private SpawnPointCollection _spawnPointCollection;

=======
    public Transform SpawnPoint; 
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
<<<<<<< HEAD
            col.gameObject.transform.position = _spawns.GetChild(_spawnPointCollection._currentActivePoint).transform.position;
        }    
    }
=======
            col.gameObject.GetComponent<CharacterController>().enabled = false;
            col.gameObject.transform.position = SpawnPoint.position;
            
            StartCoroutine(ReturnCharacterController(col.gameObject));
        }    
    }
    private IEnumerator ReturnCharacterController(GameObject player)
    {
        yield return  new WaitForSeconds(0.3f);

        player.GetComponent<CharacterController>().enabled = true;
    }
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
}
