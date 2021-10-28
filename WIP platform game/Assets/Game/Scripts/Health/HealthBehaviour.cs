using System;
using UnityEngine;

namespace Game.Scripts.Health
{
    public abstract class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private HealthData startingHealthData;
        
        public int health { get; private set; }

        private void Awake()
        {
            health = startingHealthData.startingHealth;
        }

        public void ModifyHealth(int value)
        {
            health += value;
            Debug.Log(health);
        }
    }    
}

