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
        if (Vector3.Distance(agent.transform.position,
                agent.home.position) < 3.5f)
        {
            Debug.Log(
                "<color=red>[Actie] Naar huis gaan om te eten...</color>");
            agent.MoveTo(agent.home.position);

            // Simuleer dat hij thuis is en heeft gegeten
            agent.isHungry = false;
            return NodeState.SUCCESS;
        }
        Debug.Log("<color=red>[Action] Onderweg naar huis om te eten </color>");
        agent.MoveTo(agent.home.position);
        state =  NodeState.RUNNING;
        return state;
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
        if (Vector3.Distance(agent.transform.position,
                agent.pizzaria.position) < 3.5f)
        {
            Debug.Log(
                "<color=cyan>[Actie] Pizza ophalen bij de Pizzeria...</color>");
            agent.hasPizza = true;
            return NodeState.SUCCESS;
        }
        Debug.Log("<color=cyan>[Action] Onderweg naar de pizzaria </color>");
        agent.MoveTo(agent.pizzaria.position);
        state =  NodeState.RUNNING;
        return state;
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
        if (Vector3.Distance(agent.transform.position,
                agent.customer.position) < 2.5f)
        {
            Debug.Log(
                "<color=green>[Actie] Pizza bezorgen bij het juiste adres!</color>");
            agent.hasPizza = false;
            agent.MoveTo(agent.customer.position);
            return NodeState.SUCCESS;
        }
        Debug.Log("<color=green>[Action] Onderweg naar klant </color>");
        agent.MoveTo(agent.customer.position);
        state =  NodeState.RUNNING;
        return state;
    }
}

public class CheckEnergy : Node
{
    private PizzaDeliveryAgent agent;

    public CheckEnergy(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        if (agent.energy < 25)
        {
         Debug.Log($"<color=yellow>[Condition] Energy is low! ({agent.energy})</color>");   
         return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}

public class RechargeEnergy : Node
{
    private PizzaDeliveryAgent agent;

    public RechargeEnergy(PizzaDeliveryAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(agent.transform.position,
            agent.rechargechamber.position);
        if (distance < 4.0f)
        {
            Debug.Log("<color=yellow>[Action] Fully Charged! Energy is 100%</color>");
            agent.energy = agent.maxEnergy;
            return NodeState.SUCCESS;
        }
        Debug.Log("<color=yellow>[Actie] Op weg naar oplaadstation...</color>");
        agent.MoveTo(agent.rechargechamber.position);
        state = NodeState.RUNNING;
        return state;
    }
}