using System.Collections;
using UnityEngine;


    public class Restart : State
    {
        public Restart(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

        public override void EnterState()
        {
            /*Debug.Log(3);*/
            /*enemyStateMachine.rb.AddForce(Vector3.up);
            enemyStateMachine.joint.maxDistance = 0;
            enemyStateMachine.NewWebLocation(50);
            enemyStateMachine.StartCoroutine(ToIdle());*/
        }

        public override void Update()
        {
            //enemyStateMachine.IsWebActive(true);
        }

        private IEnumerator ToIdle()
        {
            yield return new WaitForSeconds(4f);
            enemyStateMachine.SwitchState(new Idle(enemyStateMachine));
        }
    }
