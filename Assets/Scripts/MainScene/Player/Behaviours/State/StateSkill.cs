using UnityEngine;

public class StateSkill : StateAttack
{
    public StateSkill(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Skill Enter");
    }

    public override void Exit()
    {
        Debug.Log("State Skill Exit");
    }
}