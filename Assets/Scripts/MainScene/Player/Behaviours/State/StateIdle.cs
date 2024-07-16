using UnityEngine;

public class StateIdle : StateBase
{
    public StateIdle(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Idle Enter");
        // animation will be preferred to set in this part
        Managers.Game.player.SpumPrefabs.PlayAnimation(nameof(SPUM_AnimClipList.idle));
    }

    public override void Exit()
    {
        Debug.Log("State Idle Exit");
    }

    public override bool CanTransitState(IState state)
    {
        return true;
    }
}