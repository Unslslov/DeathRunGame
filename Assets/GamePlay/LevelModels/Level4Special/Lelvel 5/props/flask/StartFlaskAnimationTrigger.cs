using UnityEngine;

public class StartFlaskAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim; 

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            anim.SetBool("PlayerInFlask", true);
        }
    }

    private void OnTriggerExit(Collider col) 
    {
        anim.SetBool("PlayerInFlask", false);
    }
}
