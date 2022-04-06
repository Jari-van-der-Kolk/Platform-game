using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDir : MonoBehaviour
{

    public float speed = 0.1f;
    private Transform playerTransform;
    
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (playerTransform.position - transform.position) * speed;
        transform.position += dir;
    }
}
