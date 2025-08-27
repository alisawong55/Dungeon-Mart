using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int coin;
    public int gem;
    public List<int> items = new List<int>();

    public void AddItem(int index, int quantity)
    {
        items[index] += quantity;
    }

    public int GetItemAmount(int index){
        return items[index];
    }
}
