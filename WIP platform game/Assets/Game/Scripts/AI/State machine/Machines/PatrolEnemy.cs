using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : EnemyStateMachine
{
    public Collider2D groundedBody;


    private void Start()
    {
        currentState = _partoling;
    }

    private void Update()
    {
        
    }
}
