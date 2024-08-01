using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _laserDistance;
    [SerializeField] private LayerMask _ignoreMask;


    private RaycastHit _raycastHit;
    private Ray _ray;

    private void OnValidate() 
    {
        _lineRenderer ??= GetComponent<LineRenderer>();
    }

    private void Update() 
    {
        _ray = new Ray(transform.position, transform.up * _laserDistance);

        if(Physics.Raycast(_ray, out _raycastHit, _laserDistance, ~_ignoreMask))
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _raycastHit.point);
        }
        else 
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, transform.position + transform.up * _laserDistance);
        }
    }
}