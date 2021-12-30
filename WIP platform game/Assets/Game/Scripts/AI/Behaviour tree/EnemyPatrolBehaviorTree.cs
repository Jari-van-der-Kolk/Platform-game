using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPatrolBehaviorTree : OnHit
{

    [SerializeField] private float knockbackDelay;
    [SerializeField] private float knockbackDelayMultiplayer;
    [SerializeField] private Vector2 knockbackStrength;
    
    public ActionNode partolNode;
    public ActionNode knockback;
    public DelayNode moveDelay;
    public Sequence knockbackSequence;
    public Selector rootNode;

     private bool isHit;

    
    private void Start()
    {
        isHit = false;

        partolNode = new ActionNode(HitCheck);
        knockback = new ActionNode(PerformKnockback);
        moveDelay = new DelayNode(knockbackDelayMultiplayer);

        knockbackSequence = new Sequence(new List<Node>
        {
            knockback,
            moveDelay
        });
        
        //TODO Check of de delayNode wel werkt
        //TODO maak de code voor de knockback
        //TODO maak de Execute() method verder af
        //TODO maak de patrol method
        //TODO zorg ervoor dat de bitch werkt
         

        rootNode = new Selector(new List<Node>
        {
            partolNode,
            knockbackSequence
        });
    }

    private void Update()
    {
        Evaluate();
    }
    
    public void Evaluate() {
        rootNode.Evaluate();
        Execute();
    }

    public void Execute()
    {
        
    }

    private NodeStates HitCheck()
    {
        if (!isHit)
            return NodeStates.FAILURE;
        else
            return NodeStates.SUCCESS;
    }

    private NodeStates PerformKnockback()
    {
        isHit = false;
        EnemyFunctions.KnockBack(rb, knockbackStrength);
        return NodeStates.SUCCESS;
    }
    

    public override void Hit(float dot)
    {
        health.ModifyHealth(-1);
        isHit = true;
        if (dot> 0)
        {
            knockbackStrength *= 1f;
        }

        if (dot < 0)
        {
            knockbackStrength *= -1f;
        }
    }
}

public class yeet
{
    /*private Player playerData;    
    private Player ownData;*/

    public RandomBinaryNode buffCheckRandomNode;
    public ActionNode buffCheckNode;
    public ActionNode healthCheckNode;
    public ActionNode attackCheckNode;
    public Sequence buffCheckSequence;
    public Selector rootNode;

    public delegate void TreeExecuted();
    public event TreeExecuted onTreeExecuted;

    public delegate void NodePassed(string trigger);
    
	void Start () {        
        /* First, the AI checks its own health. If it's low, it will want to heal */
        //healthCheckNode = new ActionNode(CriticalHealthCheck);

        /* Next, the AI will check the player's heatlth. If it's low, it will always
         * go for the kill */
        //attackCheckNode = new ActionNode(CheckPlayerHealth);

        /* If neither the player nor the AI are low in health, the AI will 
         * prioritize using a defensive buff. To avoid having the AI buff every turn, 
         we use a binary randomizer to only do it half the time. */
        buffCheckRandomNode = new RandomBinaryNode();
        //buffCheckNode = new ActionNode(BuffCheck);
        buffCheckSequence = new Sequence(new List<Node> {
            buffCheckRandomNode,
            buffCheckNode,
        });

        rootNode = new Selector(new List<Node> {
            healthCheckNode,
            attackCheckNode,
            buffCheckSequence,
        });
	}

    /*public void SetPlayerData(Player human, Player ai) {
        playerData = human;
        ownData = ai;
    }*/
	
	public void Evaluate() {
        rootNode.Evaluate();
        //StartCoroutine(Execute());
    }

    private IEnumerator Execute() {
        Debug.Log("The AI is thinking...");
        yield return new WaitForSeconds(2.5f);

        if(healthCheckNode.nodeState == NodeStates.SUCCESS) {
            Debug.Log("The AI decided to heal itself");
            //ownData.Heal();
        } else if(attackCheckNode.nodeState == NodeStates.SUCCESS) {
            Debug.Log("The AI decided to attack the player!");
            //playerData.Damage();
        } else if (buffCheckSequence.nodeState == NodeStates.SUCCESS) {
            Debug.Log("The AI decided to defend itself");
            //ownData.Buff();
        } else {
            Debug.Log("The AI finally decided to attack the player");
            //.Damage();
        }
        if(onTreeExecuted != null) {
            onTreeExecuted();
        }
    }


    /*private NodeStates CriticalHealthCheck() {
        /*if(ownData.HasLowHealth) {
            return NodeStates.SUCCESS;
        } else {
            return NodeStates.FAILURE;
        }#1#
    }

    private NodeStates CheckPlayerHealth() {
        /*if(playerData.HasLowHealth) {
            return NodeStates.SUCCESS;
        } else {
            return NodeStates.FAILURE;
        }#1#
    }

    private NodeStates BuffCheck() {
        /*if(!ownData.IsBuffed) {
            return NodeStates.SUCCESS;
        } else {
            return NodeStates.FAILURE;
        }#1#
    }*/
}
 