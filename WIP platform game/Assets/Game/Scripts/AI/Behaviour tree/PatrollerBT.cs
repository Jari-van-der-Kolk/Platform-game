using System;
using System.Collections.Generic;
using JBehaviourTree;
using UnityEngine;

    public class PatrollerBT : MonoBehaviour
    {
        [SerializeField] private bool check1;
        [SerializeField] private bool check2;
        
        private RootNode tree;

        private void Start()
        {
            var log1 = new DebugLogNode("1");
            var log2 = new DebugLogNode("2");

            var check = new GenericActionNode(BoolCheck1);
            
            var sequence = new SequenceNode(new List<Node>
            {
                check  ,log1, log2
            });
            
            var repeat = new RepeatNode(sequence);
            

            tree = new RootNode(repeat);
        }
        private void Update()
        {
            tree.Update();
        }

        private Node.State BoolCheck1()
        {
            Debug.Log(1);
            if (check1)
            {
                return Node.State.Success;
            }
            else
            {
                return Node.State.Failure;
            }
        }

        private Node.State BoolCheck2()
        {
            Debug.Log(2);
            if (check2)
                return Node.State.Success;

            return Node.State.Failure;
        }
    }
