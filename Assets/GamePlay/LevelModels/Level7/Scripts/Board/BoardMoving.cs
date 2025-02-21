using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BoardMoving : MonoBehaviour
{
    [SerializeField] private  float _needTime = 5f;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _duration = 3f;
    private bool isCanMoving = true;

    private void OnValidate() 
    {
        _points = new Transform[_path.childCount];

        for(int i=0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
        // StartCoroutine(MoveAlongPath());

    public IEnumerator MoveAlongPath()
    {
        if(isCanMoving)
        {
            foreach (Transform target in _points)
            {
                // Перемещение с использованием DOTween
                transform.DORotate(target.rotation.eulerAngles, _duration);
                yield return transform.DOMove(target.position, _needTime).WaitForCompletion();
                // yield return transform.DORotate(target.rotation.eulerAngles, _duration).WaitForCompletion();
            }
            isCanMoving = false; 
        }
    }
}
