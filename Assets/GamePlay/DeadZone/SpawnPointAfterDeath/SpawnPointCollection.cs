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
        if(_spawnPointAfterDeaths.Count == 0)
        {
            for(int i = 0; i < _spawns.childCount; i++)
            {
                var childSpawn = _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>(); 

                childSpawn.NumberPoint = i;
                childSpawn.GetNumberPoint += GetPoint;
                
                _spawnPointAfterDeaths.Add(childSpawn);
            }
        }
        else
        {
            for(int i = 0; i < _spawns.childCount; i++)
            {
                _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>().GetNumberPoint += GetPoint;
            }
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
            var childSpawn = _spawns.GetChild(i).GetComponent<SpawnPointAfterDeath>(); 

            childSpawn.GetNumberPoint -= GetPoint;
            _spawnPointAfterDeaths.Remove(childSpawn);
        }
    }
}
