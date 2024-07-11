using Unity.VisualScripting;
using UnityEngine;

public class StateInteract : StateBase
{
    public StateInteract(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Interact Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Interact Exit");
    }

    public override bool CanTransitState(IState state)
    {
        if (state is StateDie)
        {
            Debug.Log($"Cannot transit to {GetType()} from {nameof(StateDie)}");
            return false;
        }
        if (state is StateDie or StateHit or StateAttack or StateEvade or StateSkill)
            return false;
        return true;
    }
}