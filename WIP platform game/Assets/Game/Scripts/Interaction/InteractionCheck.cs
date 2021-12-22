using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class InteractionCheck : MonoBehaviour, IInteractionCheck
{

    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    private Transform _Location;
    public Collider2D[] results { get; set; }

    [SerializeField] private Collider2D[] debug;

    private void Awake()
    {
        //we will already get the Transform here so that it does not have to do it again when writing your usual transform.position 
        _Location = GetComponent<Transform>();
    }
    
    public Collider2D[] Check()
    {
        //puts all the of the items that the function detects in the array that is called "r"
        debug = Physics2D.OverlapCircleAll(_Location.position, radius, layerMask);
        return debug;
    }

    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
       #endif
    }
}
