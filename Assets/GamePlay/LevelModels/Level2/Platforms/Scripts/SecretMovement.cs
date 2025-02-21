using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _allPoints;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _time = 2f;


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
                StartCoroutine(PlayerOnTheEndOfPath());
            }
            else 
            {
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
        else 
        {
            _currentPoint = 0;
            
            Transform target = _points[_currentPoint];

            if(transform.position != target.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.fixedDeltaTime);
            }
        }
    }

    IEnumerator PlayerOnTheEndOfPath()
    {
        yield return  new WaitForSeconds(_time);

        _currentPoint = 0;

        isPlayerOnTheSecretPlatform = false;
    }
}
