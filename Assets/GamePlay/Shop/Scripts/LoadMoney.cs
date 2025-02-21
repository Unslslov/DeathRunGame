using UnityEngine;
using Unsl;

public class LoadMoney : MonoBehaviour
{
    void Start()
    {
        var money = FileSaveLoad.Load<int>();

        if(money != null)
        {
            Money.coins = money.item;
        }
        else
        {
            Money.coins = 0;
        }
    }
}

