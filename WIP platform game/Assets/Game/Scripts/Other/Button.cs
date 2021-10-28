using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteract
{
    public void Action()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("faggot");
        }        
    }
}
