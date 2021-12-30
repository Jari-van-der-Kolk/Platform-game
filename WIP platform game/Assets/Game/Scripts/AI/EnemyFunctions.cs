using UnityEngine;

public class EnemyFunctions
{
    public static void KnockBack(Rigidbody2D rb, Vector2 dir)
    {
        rb.velocity = dir;
    }
}
