using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class OnHit : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector2 knockback;
    private Health health;
    private Rigidbody2D rb;
    private Transform playerTransform;
    
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    public void Hit(float dot)
    {
        if (dot > 0)
        {
            rb.velocity = -knockback;
        }
        if (dot <= 0)
        {
            rb.velocity = knockback;
        }
        health.ModifyHealth(-1);
    }
}


