using System.Collections.Generic;
using Player;
using UnityEngine;

public class KnifeDistributor : MonoBehaviour
{
    [SerializeField] private List<KnifeAttribute> _knifes;
    [SerializeField] private KnifeСell _cell;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _weaponOnScene; // Place of weapon installation on the hand character's transform
    [SerializeField] private Movement _playerMovement;

    private void OnEnable() 
    {
        _knifes.ForEach(item => 
        {
            var cell = Instantiate(_cell, _container);
            cell.Render(item, _weaponOnScene, _playerMovement);
        });   
    }

    private void OnDisable() 
    {
        int childCount = _container.childCount;

       for(int i = childCount - 1; i >= 0; i--)
       { 
           Destroy(_container.GetChild(i).gameObject); 
       }
    }
}
