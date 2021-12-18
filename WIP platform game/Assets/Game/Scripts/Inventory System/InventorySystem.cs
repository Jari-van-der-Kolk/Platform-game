using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    
    void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    
}
