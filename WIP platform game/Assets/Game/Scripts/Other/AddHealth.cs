using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Health;
using UnityEngine;

public class AddHealth : MonoBehaviour, IInteract
{
    private Health _playerHealth;
    
    private void Awake()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void Action()
    {
        //_playerHealth.ModifyHealth(10);
        gameObject.SetActive(false);
    }

    public string DisplayText()
    {
        return "Press [E] to pickup health";
    }
}