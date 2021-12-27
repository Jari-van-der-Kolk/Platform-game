using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    public int health { get { return _health; } }

    [SerializeField] private bool useEvent = true;
    [SerializeField] private UnityEvent hitEvent;
    
    public void ModifyHealth(int amount)
    {
        _health += amount;
        if(useEvent) hitEvent?.Invoke();
        if(_health <= 0) Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
