using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Vector2 attackOffset;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float attackSpeed;
    [SerializeField]private float timer;
    
    private Transform t;
    private Controller2D c;
    void Awake()
    {
        c = GetComponentInParent<Controller2D>();
        t = GetComponent<Transform>();
    }
    void Update()
    {
        Debug.Log("Attack");

        timer += Time.deltaTime * attackSpeed;
        
        if (Input.GetMouseButtonDown(0) && timer >= 1f)
        {
            Debug.Log("Attack");
            Attack();
            timer = 0;
        }
    }
    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(attackOffset.x * c.collisions.faceDir, attackOffset.y), attackRadius, enemyMask);
        foreach (Collider2D h in hits)
        {
            float dot = Vector2.Dot(Vector2.right, (h.transform.position - transform.position).normalized);
            h.GetComponent<IHitable>().Hit(dot);
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
