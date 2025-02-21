using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _allPoints;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _time = 2f;

    [SerializeField] Vector3 rotation;
    [SerializeField] private float _duration = 5f;

    public bool isPlayerOnTheSecretPlatform;
    
    private int _currentPoint = 0;

    private void OnValidate() 
    {
        if(_points.Count == 0)
        {
            for(int i = 0; i < _allPoints.childCount; i++)
            {
                _points.Add(_allPoints.GetChild(i));
            } 
        }
    }

    void FixedUpdate()
    {
        if(isPlayerOnTheSecretPlatform)
        {
            Transform target = _points[_currentPoint];

            if(transform.position != target.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.fixedDeltaTime);
            }
            else
            {
                
                transform.DORotate(rotation, _duration);

                isPlayerOnTheSecretPlatform = false;
            
            }
        }
    }
}
