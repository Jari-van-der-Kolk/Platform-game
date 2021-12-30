using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundPatrol : MonoBehaviour
{
    [SerializeField] private bool mustPatrol;
    [SerializeField] private bool mustTurn;
    [SerializeField] private float walkSpeed;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Collider2D bodyCollider;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Patrol();
        if (CheckForFlip())
        {
            Flip();
        }
    }
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    bool CheckForFlip()
    {
          return Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundMask) || bodyCollider.IsTouchingLayers(groundMask);
    }
    
    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed = -walkSpeed;
    }
}
