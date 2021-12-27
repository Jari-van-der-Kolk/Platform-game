using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float moveDelay = 0.3f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Movement>();
            Vector2 knockback = player.knockbackDir;
            var playerPos = other.transform.position;
            var dot = Vector2.Dot(Vector2.right, (transform.position - playerPos).normalized);
            if (dot > 0)
            {
                StartCoroutine(player.DisableDirectionalInput(moveDelay)); 
                player.ChangeVelocityToDir(new Vector2(-knockback.x, knockback.y));
            }
            else if(dot < 0)
            {
                StartCoroutine(player.DisableDirectionalInput(moveDelay)); 
                player.ChangeVelocityToDir(new Vector2(knockback.x, knockback.y));
            }
        }
    }

   
     
}
