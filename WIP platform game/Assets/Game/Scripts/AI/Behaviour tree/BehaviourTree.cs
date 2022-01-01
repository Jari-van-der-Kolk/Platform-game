using System.Net.Mail;
using JBehaviourTree;

    public class BehaviourTree
    {
        public Node rootNode;
        public Node.State treeState = Node.State.Running;

        public BehaviourTree(Node rootNode)
        {
            this.rootNode = rootNode;
        }
        
        public Node.State Update()
        {
            if(rootNode.state == Node.State.Running)
                treeState = rootNode.Update();
            return treeState;
        }
    }
