using System;
using JBehaviourTree;
using UnityEngine;

    public class PatrollerBT : MonoBehaviour
    {
        private BehaviourTree tree;

        private void Start()
        {
            var log = new DebugLogNode(" BRUHHH!!!!!");
            tree = new BehaviourTree(log);
        }
        private void Update()
        {
            tree.Update();
        }
    }
