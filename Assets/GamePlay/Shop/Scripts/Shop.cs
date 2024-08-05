using System.Collections.Generic;
using UnityEngine;
using Unsl;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<KnifeAttribute> _allKnives;
    [SerializeField] private Transform _container;
    [SerializeField] private ShopCell _cell;
    [SerializeField] private BuyMessage _buyMessage;
    [SerializeField] private GameObject _lackOfMoneyMessage;

    private SaveLoadData<string> _loadKnives;
    // public 

    private void OnEnable() 
    {
        _loadKnives = FileSaveLoad.Load<string>(TypeSave.Knives);

        var nameKnives = _loadKnives.ListObjects;


        _allKnives.ForEach(item => 
        {
            var cell = Instantiate(_cell, _container);
            cell.Render(item, _buyMessage, _lackOfMoneyMessage, nameKnives);
        });
    }

    private void OnDisable() 
    {
        //TODO : Save All buy Items    
    }
    private void OnDestroy() 
    {
        //TODO : Save All buy Items              
    }
}
