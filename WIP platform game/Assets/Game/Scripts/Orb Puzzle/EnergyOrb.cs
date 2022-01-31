using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    private EnergyPuzzleManager energyPuzzleManager;
    
    private void Awake()
    {
        energyPuzzleManager = FindObjectOfType<EnergyPuzzleManager>();
        energyPuzzleManager.Subscribe(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
