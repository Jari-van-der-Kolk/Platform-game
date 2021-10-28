using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Health;
using UnityEngine;

public abstract class Health : HealthBehaviour, IInteract
{
    
    public void Action()
    {
        ModifyHealth(4);
        gameObject.SetActive(false);
    }

}
