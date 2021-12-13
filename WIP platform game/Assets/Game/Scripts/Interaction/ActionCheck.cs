using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ActionCheck : MonoBehaviour, IActionCheck
{

    [SerializeField] private Vector2 size;
    [SerializeField] private LayerMask layerMask;
    private Transform p;
    public RaycastHit2D[] results { get; set; }

    private void Awake()
    {
        //we will already get the Transform here so that it does not have to do it again when writing your usual transform.position 
        p = GetComponent<Transform>();
    }

    private void Start()
    {
        //length is 2 because you'll sometimes get scenarios that require more than 2 actions to happen in the scene 
        results = new RaycastHit2D[2];
    }
    
    public int Check()
    {
        //puts all the of the items that the function detects in the array that is called "r"
        return Physics2D.BoxCastNonAlloc(p.position, size, 0, Vector2.down, results, 0, layerMask);
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireCube(transform.position, size);
    }
}
