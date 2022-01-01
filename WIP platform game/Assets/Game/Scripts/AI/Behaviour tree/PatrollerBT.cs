using System;
using System.Collections.Generic;
using JBehaviourTree;
using UnityEngine;

    public class PatrollerBT : MonoBehaviour
    {
        private RootNode tree;

        private Node rootNode;

        private void Start()
        {
            var log1 = new DebugLogNode(" BRUHHH1!!!!!");
            var log2 = new DebugLogNode(" BRUHHH2!!!!!");
            var log3 = new DebugLogNode(" BRUHHH3!!!!!");
            var log4 = new DebugLogNode(" last");
            var repeat = new RepeatNode(log4);

            var sequence = new SequenceNode(new List<Node>
            {
                log1, log2, log3, repeat
            });

            tree = new RootNode(sequence);
        }
        private void Update()
        {
            tree.Update();
        }
    }
