using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopUI : MonoBehaviour
{
    public GoldUI goldUI;

    public void BuyCage(int cost)
    {
        GameManager.Instance.cageAmount++;
        GameManager.Instance.money -= cost;
    }

    public void BuyNet(int cost)
    {
        GameManager.Instance.netAmount++;
        GameManager.Instance.money -= cost;
    }

    public void BuyDart(int cost)
    {
        GameManager.Instance.dartAmount++;
        GameManager.Instance.money -= cost;
    }
}
