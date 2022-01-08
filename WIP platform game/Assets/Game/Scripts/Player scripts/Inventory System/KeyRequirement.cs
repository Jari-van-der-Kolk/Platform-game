using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyRequirement : MonoBehaviour, IInteract
{
   public InventoryItemData referenceItem;

   private int interactedAmount;
   private InventoryItem keyItem;
   private void Start()
   {
      interactedAmount = 0;
   }

   public void Action()
   {
      interactedAmount++;
      keyItem = InventorySystem.instance.Get(referenceItem);
      if (keyItem == null)
      {
         return;
      }
      InventorySystem.instance.Remove(referenceItem);
      Destroy(gameObject);
   }

   public string DisplayText()
   {
      if (interactedAmount < 1)
      {
         return "Press [E] to open door";
      }
      else if(interactedAmount >= 1 ||keyItem != null)
      {
         return "Press [E] to open door";
      }
      return "You cannot open the Door without its key";
   }
}
