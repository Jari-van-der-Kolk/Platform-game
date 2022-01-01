using System.Collections.Generic;

namespace JBehaviourTree
{
    public abstract class CompositeNode : Node
    {
        public List<Node> children = new List<Node>();
    }
}