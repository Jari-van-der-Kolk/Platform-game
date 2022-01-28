using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericInteraction : MonoBehaviour, IInteract
{
    [SerializeField] private string displayText;
    [SerializeField] private UnityEvent action;

    public void Action()
    {
        action?.Invoke();
        Destroy(gameObject);
    }

    public string DisplayText()
    {
        return displayText;
    }
}
