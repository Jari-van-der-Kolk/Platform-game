using UnityEngine;

namespace Game.Scripts.Health
{
    public abstract class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private HealthData startingHealthData;
        
        public int health
        {
            get => startingHealthData.startingHealth;
            set => startingHealthData.startingHealth = value;
        }

        public void ModifyHealth(int value)
        {
            health += value;
            Debug.Log(health);
        }
    }    
}

