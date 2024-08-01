using System.Collections;
using UnityEngine;

namespace Column
{
    public class Movement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _path;
        [SerializeField] private Transform[] _points;
        [SerializeField] private Transform _target;

        [Header("Scalar")]
        [SerializeField] private float _RotationSpeed = 5f;
        [SerializeField] private float _Verticalspeed = 1f;

        [Header("Time")]
        [SerializeField] private float TimeDelayBetweenStartMove = 1.2f;

        private bool _isMoveing = true;
        private int _currentCountPoint;
        
        private void Start() 
        {
            if(_path == null)
                return;

            _points = new Transform[_path.childCount];

            for(int i=0;  i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }

        private void FixedUpdate() 
        {
            transform.Rotate(0, 0, _RotationSpeed * Time.deltaTime);

            if(!_isMoveing)
            {
                StartCoroutine(StartMove());
            }
            else 
            {
                if(_currentCountPoint  >= _points.Length)
                    _currentCountPoint = 0;

                _target = _points[_currentCountPoint];

                if(transform.position != _target.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _target.position, _Verticalspeed * Time.fixedDeltaTime);
                }
                else
                {
                    _currentCountPoint++;
                    _isMoveing = false;
                }
            }
        }

        IEnumerator StartMove()
        {
            yield return new WaitForSeconds(TimeDelayBetweenStartMove);

            _isMoveing = true;
        }
    }
}