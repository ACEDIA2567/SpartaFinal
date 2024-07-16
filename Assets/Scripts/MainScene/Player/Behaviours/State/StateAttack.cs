using System.Collections;
using UnityEngine;

public class StateAttack : StateBase
{
    public StateAttack(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Attack Enter");
        Managers.Game.player.SpumPrefabs.PlayAnimation(nameof(SPUM_AnimClipList.Attack_Normal));
        // this.animator.GetCurrentAnimatorStateInfo(0)
    }

    public override void Exit()
    {
        // Debug.Log(Managers.Game.player.SpumPrefabs._anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Debug.Log("State Attack Exit");
        // UniTask
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