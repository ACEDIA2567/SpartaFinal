using UnityEngine;

public class StateDie : StateBase
{
    public StateDie(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Die Enter");
        Managers.Game.player.SpumPrefabs.PlayAnimation(nameof(SPUM_AnimClipList.Death));
    }

    public override void Exit()
    {
        Debug.Log("State Die Exit");
    }

    public override bool CanTransitState(IState state)
    {
        return true;
    }
}