using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType{
    coin, gem
    }

[CreateAssetMenu(fileName = "ItemData", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemID;
    public int sid;
    public string itemName;
    public CurrencyType currencyType;
    public int cost;
    public Sprite icon;
}
