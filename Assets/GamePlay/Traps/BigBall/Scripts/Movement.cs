using System.Collections;
using UnityEngine;

namespace BigBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [Header("Scalarities")]
        [SerializeField] private float _forwardspeed = 5f;
        [SerializeField] private float _bouncespeed = 0f;

        [Header("ReferencesAndBooling")]
        [SerializeField] private Transform _pointToMove;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private bool _isBounced = false;

        [Header("SpawnSettings")]
        [SerializeField] private float _intervalSpawn = 3f;

        private  Rigidbody _rb;

        private void OnValidate() 
        {
            _rb ??= GetComponent<Rigidbody>();    
        }

        private void OnCollisionEnter(Collision col) 
        {
            if(col.gameObject.layer == LayerMask.NameToLayer("Ground") && _isBounced == false)
            {
                _rb.velocity = _pointToMove.forward * _forwardspeed;
            }
            else if(col.gameObject.layer == LayerMask.NameToLayer("Ground") && _isBounced == true)
            {
                _rb.velocity = _pointToMove.forward * _forwardspeed + _pointToMove.up * _bouncespeed;
            }
        }

        private void OnTriggerEnter(Collider col)
        {
            if(col.CompareTag("DeathZoneForBigBall"))
            {
                StartCoroutine(ReturnBallToSpawnPoint());

                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }    
        }

        IEnumerator ReturnBallToSpawnPoint()
        {
            yield return new WaitForSeconds(_intervalSpawn);
         
            _rb.velocity = Vector3.zero;
                
            gameObject.transform.position = _spawnPoint.position;

            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}