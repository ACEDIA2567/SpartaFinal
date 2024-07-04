using UnityEngine;

public class StateMove : StateBase
{
    public StateMove(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Move Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Move Exit");
    }
}