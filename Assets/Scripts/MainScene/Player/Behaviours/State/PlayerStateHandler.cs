using UnityEngine;

public class PlayerStateHandler 
{
    public StateMachine stateMachine;

    StateBase[] states;
    public StateIdle IdleState { get; }
    public StateMove MoveState { get; }
    public StateAttack AttackState { get; }
    public StateEvade EvadeState { get; }
    public StateSkill SkillState { get; }

    public PlayerStateHandler()
    {
        Managers.Game.player.StateHandler = this;
        stateMachine = new StateMachine();

        states = new StateBase[(int)ActionType.Count];
        states[(int)ActionType.Idle] = new StateIdle(stateMachine);
        IdleState = new StateIdle(stateMachine);
        MoveState = new StateMove(stateMachine);
        AttackState = new StateAttack(stateMachine);
        EvadeState = new StateEvade(stateMachine);
        SkillState = new StateSkill(stateMachine);

    }

    public T GetOrAddState<T>(ActionType type) where T : StateBase
    {
        return states[(int)type] as T;
    }
}