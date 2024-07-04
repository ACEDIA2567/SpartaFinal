using UnityEngine;

public class StateAttack : StateBase
{
    public StateAttack(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Attack Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Attack Exit");
    }
}