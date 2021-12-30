using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Partoling _partoling;
    //public Attack _attack;
        
        
    public EnemyStateMachine()
    {
        _partoling = new Partoling(this);
        //_attack = new Attack(this);
    }
}
