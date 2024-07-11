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

    public override bool CanTransitState(IState state)
    {
        if (state is StateDie or StateAttack or StateSkill)
        {
            Debug.Log($"Cannot transit {GetType()} from {state.GetType()}");
            return false;
        }
        return true;
    }
}