using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPuzzleManager : MonoBehaviour
{
    private List<EnergyOrb> energyOrbs;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Subscribe(EnergyOrb energyOrb)
    {
        if (energyOrbs == null)
        {
            energyOrbs = new List<EnergyOrb>();
        }
        
        energyOrbs.Add(energyOrb);
    }
    
}
