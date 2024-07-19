using System.Collections.Generic;
using UnityEngine;

public class SecretMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _allPoints;
    [SerializeField] private List<Transform> _points;

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
            if(_currentPoint >= _points.Count)
            {
                _currentPoint = 0;

                isPlayerOnTheSecretPlatform = false;
            }

            Transform target = _points[_currentPoint];

            if(transform.position != target.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.fixedDeltaTime);
            }
            else
            {
                if(_currentPoint <  _points.Count)
                    _currentPoint++;
            }
        }
    }
}
