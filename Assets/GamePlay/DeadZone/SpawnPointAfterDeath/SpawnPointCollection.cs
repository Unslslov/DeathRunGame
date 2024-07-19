using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCollection : MonoBehaviour
{
    [SerializeField] private Transform _spawns; 
    [SerializeField] private List<SpawnPointAfterDeath> _spawnPointAfterDeaths;

    public int _currentActivePoint = 0;

    private void Start() 
    {
         for(int i = 0; i < _spawns.childCount; i++)
        {
            _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>().NumberPoint = i;
            _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>().GetNumberPoint += GetPoint;
            
            _spawnPointAfterDeaths.Add(_spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>());
        }
    }

    private void GetPoint(int NumberPoint)
    {
        _currentActivePoint = NumberPoint;
    }

    private void OnDestroy() 
    {
         for(int i = 0; i < _spawns.childCount; i++)
        {   
            _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>().GetNumberPoint -= GetPoint;
            _spawnPointAfterDeaths.Remove(_spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>());
        }
    }
}
