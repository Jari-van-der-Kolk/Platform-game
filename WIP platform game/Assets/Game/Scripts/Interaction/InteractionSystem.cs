using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    
    //TODO make it so that if you stand over a pile of objects.
 
    //TODO That you have the action to be able to pick everything up 
    //TODO and that you have the action to pick everything up one by one
   
    //TODO you have automatic pickups as well

    private IInteractionCheck InteractionCheck;
    
    private void Awake() => InteractionCheck = GetComponent<IInteractionCheck>();
    
    void LateUpdate()
    { 
        AutoPickup();
        var interaction = InteractionCheck.Check();
        if (interaction.Length > 0)
        {
            SinglePickup(Input.GetKeyDown(KeyCode.E), interaction[0]);
        }
        PickupAll(Input.GetKeyDown(KeyCode.R), InteractionCheck.Check());
        
    }

    private void SinglePickup(bool input, Collider2D itemCollider)
    {
        // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
        if (itemCollider != null)
        {
            var item = itemCollider.GetComponent<IInteract>();
            item.DisplayText();
            if (input)
            {
                item.Action();
            } 
        }
        
    }

    private void PickupAll(bool input, Collider2D[] itemColliders)
    {
        if (input)
        {
            foreach (var i in itemColliders)
            {
                i.GetComponent<IInteract>().Action();   
            }
        }
    }
    
    private void AutoPickup()
    {
        
    }

}
/*for (int i = 0; i < actionCheck.results.Length; i++)
      {
          var o = actionCheck.results[i];
          if (o != null)
          {
              o.GetComponent<IInteract>().Action();
          }
      }*/