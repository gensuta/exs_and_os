using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public string itemName;

    [TextArea(2, 5)]
    public string itemDescription;

    [SerializeField] int price;

    public int GetPrice()
    {
        return price;   
    }
}
