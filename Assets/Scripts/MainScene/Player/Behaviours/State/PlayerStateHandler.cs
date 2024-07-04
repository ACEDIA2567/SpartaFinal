public class PlayerStateHandler
{
    public StateMachine stateMachine;
    
    public StateIdle IdleState { get; }
    public StateMove MoveState { get; }
    public StateAttack AttackState { get; }
    public StateEvade EvadeState { get; }
    public StateSkill SkillState { get; }

    public PlayerStateHandler()
    {
        Managers.Game.player.StateHandler = this;
        stateMachine = new StateMachine();
        
        IdleState = new StateIdle(stateMachine);
        MoveState = new StateMove(stateMachine);
        AttackState = new StateAttack(stateMachine);
        EvadeState = new StateEvade(stateMachine);
        SkillState = new StateSkill(stateMachine);

    }
}