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

    void Start()
    {
        ConstructBehavioTree();
    }

    void Update()
    {
        if (topNode != null)
        {
            topNode.Evaluate();
        }
    }

    void ConstructBehavioTree()
    {
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