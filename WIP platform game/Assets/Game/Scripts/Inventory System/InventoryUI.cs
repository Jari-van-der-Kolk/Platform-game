using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
   private InventorySystem _inventorySystem;

   private void Awake()
   {
      _inventorySystem = GetComponent<InventorySystem>();
   }
   
   
}
