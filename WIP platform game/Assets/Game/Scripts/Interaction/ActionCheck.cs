using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class ActionCheck : MonoBehaviour, IActionCheck
{

    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    private Transform _Location;
    public Collider2D[] results { get; set; }


    private void Awake()
    {
        //we will already get the Transform here so that it does not have to do it again when writing your usual transform.position 
        _Location = GetComponent<Transform>();
    }
    
    public Collider2D Check()
    {
        //puts all the of the items that the function detects in the array that is called "r"
        return Physics2D.OverlapCircle(_Location.position, radius, layerMask);
    }


    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        if(_Location == null) return;
        Handles.DrawWireDisc(_Location.position, Vector3.forward, radius);
       #endif
    }
}
