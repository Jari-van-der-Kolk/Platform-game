using UnityEngine;

namespace Game.Scripts.Health
{
    public class HealthBehaviour : MonoBehaviour
    {
        private int health;

        public void ModifyHealth(int value)
        {
            health += value;
        }
    }    
}

