using UnityEngine;

public class EnemyFunctions
{
    public void KnockBack(Rigidbody2D rb, Vector2 dir)
    {
        rb.velocity = dir;
    }
}
