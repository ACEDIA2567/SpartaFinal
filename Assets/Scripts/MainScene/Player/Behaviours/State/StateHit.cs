using UnityEngine;

public class StateHit : StateBase
{
    public StateHit(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Hit Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Hit Exit");
    }

    public override bool CanTransitState(IState state)
    {
        return true;
    }
}