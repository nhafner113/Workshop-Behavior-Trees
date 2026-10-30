using UnityEngine;

// Hier staan specifieke actie- en conditie nodes (leafs)

// Condities

public class CheckHunger : Node
{
    private PizzaDeliveryAgent agent;

    public CheckHunger(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        if (agent.isHungry)
        {
            Debug.Log("<color=orange>[Conditie] Delivery Agent is hungry</color>");
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}

public class HasPizza : Node
{
    private PizzaDeliveryAgent agent;

    public HasPizza(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }
    
    public override NodeState Evaluate()
    {
        return agent.hasPizza ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}

// Acties

public class GoHomeToEat : Node
{
    private PizzaDeliveryAgent agent;

    public GoHomeToEat(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("<color=red>[Actie] Naar huis gaan om te eten...</color>");
        agent.MoveTo(agent.home.position);
        
        // Simuleer dat hij thuis is en heeft gegeten
        agent.isHungry = false;
        return NodeState.SUCCESS;
    }
}

public class PickupPizza : Node
{
    private PizzaDeliveryAgent agent;

    public PickupPizza(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("<color=cyan>[Actie] Pizza ophalen bij de Pizzeria...</color>");
        agent.MoveTo(agent.pizzaria.position);
        
        agent.hasPizza = true;
        return NodeState.SUCCESS;
    }
}

public class DeliverPizza : Node
{
    private PizzaDeliveryAgent agent;

    public DeliverPizza(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("<color=green>[Actie] Pizza bezorgen bij het juiste adres!</color>");
        agent.MoveTo(agent.customer.position);
        
        agent.hasPizza = false;
        return NodeState.SUCCESS;
    }
}