using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform t;
    [SerializeField] private Vector2 attackOffset;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyMask;
    private Controller2D c;
    void Start()
    {
        c = GetComponentInParent<Controller2D>();
        t = GetComponent<Transform>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Attack()
    {
        Debug.Log("Attack");
        Collider2D[] hits = Physics2D.OverlapCircleAll(t.position + new Vector3(attackOffset.x * c.collisions.faceDir, attackOffset.y), attackRadius, enemyMask);
        foreach (Collider2D h in hits)
        {
            h.GetComponent<Health>().ModifyHealth(-1);
        }
    }
    private void OnDrawGizmosSelected()
    {
        #if UNITY_EDITOR
        Handles.color = Color.red;
        c = GetComponentInParent<Controller2D>();
        Handles.DrawWireDisc(transform.position + new Vector3(attackOffset.x * c.collisions.faceDir, attackOffset.y)  , Vector3.forward, attackRadius);
        #endif
    }
}
