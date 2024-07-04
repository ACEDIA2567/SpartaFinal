using UnityEngine;

public class StateIdle : StateBase
{
    public StateIdle(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Idle Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Idle Exit");
    }
}