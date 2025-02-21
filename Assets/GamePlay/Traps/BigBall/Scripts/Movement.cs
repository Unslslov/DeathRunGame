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

        [SerializeField] private  Rigidbody _rb;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Collider _collider;

        private void OnValidate() 
        {
            _rb ??= GetComponent<Rigidbody>();  
            _meshRenderer ??= GetComponent<MeshRenderer>();
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

                _meshRenderer.enabled = false;
                _collider.enabled = false;
            }    
        }

        IEnumerator ReturnBallToSpawnPoint()
        {
            yield return new WaitForSeconds(_intervalSpawn);
         
            _rb.velocity = Vector3.zero;
                
            gameObject.transform.position = _spawnPoint.position;

           _meshRenderer.enabled = true;
           _collider.enabled = true;
        }
    }
}