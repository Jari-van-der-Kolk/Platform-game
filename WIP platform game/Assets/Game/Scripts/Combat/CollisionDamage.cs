using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float dot;
    public static event Action<CollisionDamage, float> onEnemyHit = delegate{  };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            dot = Vector2.Dot(Vector2.right, (transform.position - other.transform.position).normalized);
            onEnemyHit?.Invoke(this, dot);
        }
    }
}

/*Vector2 knockback = _movement.knockbackDir;
var enemyPos = other.transform.position;
var dot = Vector2.Dot(Vector2.right, (transform.position - enemyPos).normalized);
if (dot > 0)
{
    _movement.ChangeVelocityToDir(new Vector2(knockback.x, knockback.y));
}
else if(dot < 0)
{
    _movement.ChangeVelocityToDir(new Vector2(-knockback.x, knockback.y));
}*/
