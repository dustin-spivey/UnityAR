using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory.asset")]
public class InventoryList : ScriptableObject
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
}

[System.Serializable]
public class InventorySlot
{
    public InventoryItem item;
    public InventorySlot(InventoryItem _item)
    {
        item = _item; 
    }
}
