using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _laserDistance;

    [Header("PlayerSpawn")]
    [SerializeField] private Transform _spawns; 
    [SerializeField] private SpawnPointCollection _spawnPointCollection;

    private RaycastHit _raycastHit;
    private Ray _ray;

    private void OnValidate() 
    {
        _lineRenderer ??= GetComponent<LineRenderer>();
    }

    private void Update() 
    {
        _ray = new Ray(transform.position, transform.up * _laserDistance);
        Debug.DrawRay(transform.position, transform.up * _laserDistance);

        if(Physics.Raycast(_ray, out _raycastHit, _laserDistance))
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _raycastHit.point);

            if(_raycastHit.collider.CompareTag("Player"))
            {
                _raycastHit.collider.gameObject.transform.position = _spawns.GetChild(_spawnPointCollection._currentActivePoint).transform.position;
            }
        }
        else 
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, transform.position + transform.up * _laserDistance);
        }

        // if(Physics.Raycast(_ray, out _raycastHit, _laserDistance, ~_ignoreMask))
        // {
        //     _lineRenderer.SetPosition(0, transform.position);
        //     _lineRenderer.SetPosition(1, _raycastHit.point);

        //     if(_raycastHit.collider.CompareTag("Player"))
        //     {
        //         _raycastHit.collider.gameObject.transform.position = _spawns.GetChild(_spawnPointCollection._currentActivePoint).transform.position;
        //     }
        // }
        // else
        // {
        //     _lineRenderer.SetPosition(0, transform.position);
        //     _lineRenderer.SetPosition(1, transform.position + _raycastHit.point);
        // }
    }
}