using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] string currencyName;
    [SerializeField] int currencyAmount;

    public int amount { get { return this.currencyAmount; } }

    public event Action CurrencyChanged;

    public void ReceiveCurrency(int amt)
    {
        currencyAmount += amt;
        CurrencyChanged?.Invoke();
    }

    public void UseCurrency(int price)
    {

        currencyAmount -= price;
        CurrencyChanged?.Invoke();

    }

    public void DisplayCurrency(TextMeshProUGUI t)
    {
        t.text = currencyName + ": " +currencyAmount;
    }
}
