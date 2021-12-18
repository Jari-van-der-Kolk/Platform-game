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

    private IActionCheck actionCheck;
    
    private void Awake() => actionCheck = GetComponent<IActionCheck>();
    
    void Update()
    { 
        AutoPickup();
        PickupAction(Input.GetKeyDown(KeyCode.E), actionCheck.Check());
        
    }

    private void PickupAction(bool input, Collider2D itemCollider)
    {
        if (input) itemCollider.gameObject.SetActive(false);
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