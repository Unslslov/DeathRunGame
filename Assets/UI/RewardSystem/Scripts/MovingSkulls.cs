using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MovingSkulls : MonoBehaviour
{
    [SerializeField] private  float _needTime = 5f;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _duration = 3f;

    private void OnValidate() 
    {
        _points = new Transform[_path.childCount];

        for(int i=0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

   private void Start()  
    { 
        StartCoroutine(MoveAlongPath());
    } 

    private IEnumerator MoveAlongPath()
    {
        foreach (Transform target in _points)
        {
            // Перемещение с использованием DOTween
            yield return transform.DOMove(target.position, _needTime).WaitForCompletion();
            yield return transform.DORotate(target.rotation.eulerAngles, _duration).WaitForCompletion();
        }
    }
}
