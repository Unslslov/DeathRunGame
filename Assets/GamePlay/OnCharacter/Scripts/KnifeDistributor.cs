using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Unsl;

public class KnifeDistributor : MonoBehaviour
{
    [SerializeField] private List<KnifeAttribute> _knifes;
    [SerializeField] private KnifeСell _cell;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _weaponOnScene; // Place of weapon installation on the hand character's transform
    [SerializeField] private Movement _playerMovement;
    
    private void OnEnable() 
    {
        var name = FileSaveLoad.LoadList<string>(TypeSave.Knives).ListObjects;

        _knifes = CreateAccessOnKnives(_knifes, name);

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

    private List<KnifeAttribute> CreateAccessOnKnives(List<KnifeAttribute> knives, List<string> _nameWeapons)
    {
        if(knives.Count == 0)
        {
            Debug.LogError("knives isn't initialized");
            return null;
        }
        
        if(_nameWeapons.Count == 0)
        {
            Debug.LogError("_nameWeapons isn't initialized");
            return null;
        }

        List<KnifeAttribute> _accessKnives = new List<KnifeAttribute>();

        knives.ForEach(knife =>
        {
            if (_nameWeapons.Any(name => name.Equals(knife.Name)))
            {
                _accessKnives.Add(knife);
            }
        });

        return _accessKnives;
    }
}
