using System.Collections;
using UnityEngine;


    public abstract class State
    {
        protected EnemyStateMachine enemyStateMachine;

        public State(EnemyStateMachine enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }
        
        public abstract void EnterState();

        public abstract void Update();
        
        

    }
