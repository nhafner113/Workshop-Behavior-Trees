using System.Collections.Generic;
using UnityEngine;

// Hier wordt de BT opgebouwd en gekoppeld aan de unity scene

public class PizzaDeliveryAgent : MonoBehaviour
{
    private Node topNode;
    
    public bool isHungry = false;
    public bool hasPizza = false;

    public Transform pizzaria;
    public Transform customer;
    public Transform home;
    public Transform rechargechamber;

    public float energy = 200f;
    public float maxEnergy = 200f;
    public float energyDrainRate = 5f;

    void Start()
    {
        ConstructBehavioTree();
    }

    void Update()
    {
        if (energy > 0)
        { 
            energy -= energyDrainRate * Time.deltaTime;
            energy = Mathf.Clamp(energy, 0f, maxEnergy);
        }
        if (topNode != null)
        {
            topNode.Evaluate();
        }
    }

    void ConstructBehavioTree()
    {
        // Assignment
        Node energyCheck = new CheckEnergy(this);
        Node rechargeAction = new RechargeEnergy(this);
        Sequence energySequence = new Sequence(new List<Node> { energyCheck, rechargeAction });
        
        
        // Branch 1: Als de bezorger honger heeft --> Ga naar huis om te eten.
        Node hungryCheck = new CheckHunger(this);
        Node goHome = new GoHomeToEat(this);
        Sequence eatSequence = new Sequence(new List<Node> { hungryCheck, goHome });
        
        // Branch 2: Als hij al een pizza heeft --> Bezorg hem bij de klant.
        Node hasPizzaCheck = new HasPizza(this);
        Node deliverAction = new DeliverPizza(this);
        Sequence deliverSequence = new Sequence(new List<Node> { hasPizzaCheck, deliverAction });
        
        // Branch 3: Anders --> Haal een pizza op bij de Pizzaria
        Node pickupAction = new PickupPizza(this);
        
        // Selector kiest de eerste die slaagt
        topNode = new Selector(new List<Node>
        {
            energySequence,
            eatSequence,
            deliverSequence,
            pickupAction,
        });
    }

    public void MoveTo(Vector3 targetPosition)
    {
        // Only y-as
        Vector3 target = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }

}