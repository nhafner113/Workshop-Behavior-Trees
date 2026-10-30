using UnityEngine;
using System.Collections.Generic;

// basis systeem
// Bevat de NodeState enum (running, succes, failure 
// bevat abstracte Node klasse waar alle andere Nodes van overerven.


public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public abstract class Node
{
    public NodeState state;
    public abstract NodeState Evaluate();
}
