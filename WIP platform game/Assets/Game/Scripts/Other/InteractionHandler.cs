using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    private IActionCheck actionCheck;
    
    private void Awake() => actionCheck = GetComponent<IActionCheck>();
    
    void Update()
    {
        actionCheck.Check();
        for (int i = 0; i < actionCheck.results.Length; i++)
        {
            var o = actionCheck.results[i].collider;
            if (o != null && o.isActiveAndEnabled)
            {
                o.GetComponent<IInteract>().Action();
                o = null;
            }
        }
    }
}
