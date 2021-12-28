using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float moveDelay = 0.3f;
    private Movement _movement;

    private void Awake() => _movement = GetComponent<Movement>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector2 knockback = _movement.knockbackDir;
            var enemyPos = other.transform.position;
            var dot = Vector2.Dot(Vector2.right, (transform.position - enemyPos).normalized);
            if (dot > 0)
            {
                StartCoroutine(_movement.DisableDirectionalInput(moveDelay)); 
                _movement.ChangeVelocityToDir(new Vector2(knockback.x, knockback.y));
            }
            else if(dot < 0)
            {
                StartCoroutine(_movement.DisableDirectionalInput(moveDelay)); 
                _movement.ChangeVelocityToDir(new Vector2(-knockback.x, knockback.y));
            }
        }
    }

   
     
}
