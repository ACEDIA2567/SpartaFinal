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

    public override bool CanTransitState(IState state)
    {
        // below two condition works same
        //if (state.GetType() == typeof(StateDie) || state.GetType() == typeof(StateEvade))
        if (state is StateDie or StateEvade)
        {
            Debug.Log($"Cannot transit {GetType()} from {state.GetType()}");
            return false;
        }
        return true;
    }
}