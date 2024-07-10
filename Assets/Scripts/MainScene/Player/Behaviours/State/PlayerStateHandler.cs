using UnityEngine;

public class PlayerStateHandler 
{
    public StateMachine stateMachine;

    StateBase[] states;
    public StateIdle Idle { get; }
    public StateMove Move { get; }
    public StateAttack Attack { get; }
    public StateEvade Evade { get; }
    public StateSkill Skill { get; }

    public PlayerStateHandler()
    {
        Managers.Game.player.StateHandler = this;
        stateMachine = new StateMachine();

        states = new StateBase[(int)ActionType.Count];
        states[(int)ActionType.Idle] = new StateIdle(stateMachine);
        Idle = new StateIdle(stateMachine);
        Move = new StateMove(stateMachine);
        Attack = new StateAttack(stateMachine);
        Evade = new StateEvade(stateMachine);
        Skill = new StateSkill(stateMachine);

    }

    public T GetOrAddState<T>(ActionType type) where T : StateBase
    {
        return states[(int)type] as T;
    }
}