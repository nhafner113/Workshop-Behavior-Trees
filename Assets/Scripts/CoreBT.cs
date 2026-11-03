
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
