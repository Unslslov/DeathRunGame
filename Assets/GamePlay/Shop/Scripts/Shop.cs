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
    [SerializeField] private BuyButton _BuyButton;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip  _clip;

    [HideInInspector] public ShopCell _currentActiveCell;

    private List<string> _saveKnifes;
    private SaveLoadListData<string> _loadKnives;

    private void OnEnable() 
    {
        _BuyButton.OnBuyEvent += SaveKnife; 

        _loadKnives = FileSaveLoad.LoadList<string>(TypeSave.Knives);

        List<string> nameKnives = _loadKnives.ListObjects;

        if(!nameKnives.Contains("Axe"))
        {
            nameKnives.Add("Axe");
        }

        _allKnives.ForEach(item => 
        {
            var cell = Instantiate(_cell, _container);
            cell.Render(item, _buyMessage, _lackOfMoneyMessage, nameKnives);
            cell.InitializedSound(_audioSource, _clip);

            cell.CurrentActiveShopCellEvent += GetCurrentCell; // TODO: Unsubscribe this event
        });

        _saveKnifes = nameKnives;
    }

    private void OnDisable() 
    {
        _BuyButton.OnBuyEvent -= SaveKnife; 

        for(int i = _container.childCount - 1; i >= 0; i--)
        {
            var knife = _container.GetChild(i).GetComponent<ShopCell>();;

            knife.CurrentActiveShopCellEvent -= GetCurrentCell;

            Destroy(knife.gameObject);
        }

        if(_saveKnifes.Count != 0)
            FileSaveLoad.Save<string>(_saveKnifes, TypeSave.Knives);

        FileSaveLoad.Save<int>(Money.coins);
    }

    private void OnDestroy() 
    {
        _BuyButton.OnBuyEvent -= SaveKnife; 
            
        if(_container.childCount != 0)
        {
            for(int i = _container.childCount - 1; i > 0; i--)
            {
                var knife = _container.GetChild(i).GetComponent<ShopCell>();;

                knife.CurrentActiveShopCellEvent -= GetCurrentCell;

                Destroy(knife.gameObject);
            } 
        }

        if(_saveKnifes.Count != 0)
            FileSaveLoad.Save<string>(_saveKnifes, TypeSave.Knives);

        FileSaveLoad.Save<int>(Money.coins);
    }

    private void SaveKnife(string knife)
    {
        _saveKnifes.Add(knife);
    }
    private void GetCurrentCell(int cost, ShopCell cell)
    {
        _BuyButton.shopCell = cell;
        _BuyButton.Cost = cost;
    }
}
