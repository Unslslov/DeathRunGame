using UnityEngine;

public class CostShopCellСutOff : MonoBehaviour
{
    [SerializeField] private  GameObject _costShopCellPrefab;
    [SerializeField] private  GameObject _coin;

    public void CutOff()
    {
        _costShopCellPrefab.SetActive(false);
        _coin.SetActive(false);
    }
}
