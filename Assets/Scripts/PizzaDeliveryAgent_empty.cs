using System.Collections.Generic;
using UnityEngine;


public class PizzaDeliveryAgent_empty : MonoBehaviour
{
    private Node topNode;
    
    public bool isHungry = false;
    public bool hasPizza = false;

    public Transform pizzaria;
    public Transform customer;
    public Transform home;
    public Transform RechargeChamber;

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
       
    }

    public void MoveTo(Vector3 targetPosition)
    {
        
    }

}
