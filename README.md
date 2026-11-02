# Workshop Assignment: Energy system

## Context and Goal
Our 'PizzaDeliveryAgent' currently drives endlessly as long as they are not hungry. In this assignment, you will add an **energy system** to the behavior tree.
When the agent's energy drops below **25%**, They must stop their current task and immediately walk to the charging station to recharge.

### What you need to do

### 1. In 'PizzaDeliveryAgent.cs' 
* Add variables for current energy, maximum energy, and drain rate.
* Update the 'Update()' loop so that the energy gradually decreases over time.

### 2. The condition Node: 'CheckEnergy'
* Create a new condition node named 'CheckEnergy'.
* This node should check if agent.energy < 25%.
* Return the correct NodeStates

### 3. The action Node: 'RechargeEnergy'
* Create a new action node named 'RechargeEnergy'.
* Move the agent toward the rechargechamber.
* While the agent is traveling, return RUNNING.
* Once the agent is within **4.0 meter** of the rechargechamber.
  - reset the energy
  - return SUCCES
 
### 4. Behavior tree integration (in 'ConstructBehaviorTree')
* Create a **sequence** combining 'CheckEnergy' and 'RechargeEnergy'.
* Add this new branch to the **selector**.

## Test in Unity
* Press **Play** and observe how the agent reacts once their energy drops below 25%.
