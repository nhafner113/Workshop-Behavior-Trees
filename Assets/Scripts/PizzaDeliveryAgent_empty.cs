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
        // Branch 1: Als de bezorger honger heeft --> Ga naar huis om te eten.
     
        
        // Branch 2: Als hij al een pizza heeft --> Bezorg hem bij de klant.
        
        
        // Branch 3: Anders --> Haal een pizza op bij de Pizzaria
       
        
        // Selector building
       
    }

    public void MoveTo(Vector3 targetPosition)
    {
        
    }

}