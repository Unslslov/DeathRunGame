using System.Collections;
using UnityEngine;

public class CoroutineStart : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(StartAnimation(_delay));
    }

    private IEnumerator StartAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.enabled = true;
    } 
}
