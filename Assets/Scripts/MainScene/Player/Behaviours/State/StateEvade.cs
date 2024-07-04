using UnityEngine;

public class StateEvade : StateBase
{
    public StateEvade(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Evade Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Evade Exit");
    }
}