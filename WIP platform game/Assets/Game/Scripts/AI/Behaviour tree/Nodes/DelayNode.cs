using UnityEngine;

public class DelayNode : Node
{
    private float time;
    private float speed;
    
    public DelayNode(float speed)
    {
        time = 1f;
        this.speed = speed;
    }
    
    public override NodeStates Evaluate()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime * speed;
           return NodeStates.RUNNING;
        }
        else
        {
            time = 1f;
            return NodeStates.SUCCESS;
        }
    }
 }
