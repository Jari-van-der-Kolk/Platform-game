using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IInteract
{
    public void Action()
    {
        gameObject.SetActive(false);
    }
}
