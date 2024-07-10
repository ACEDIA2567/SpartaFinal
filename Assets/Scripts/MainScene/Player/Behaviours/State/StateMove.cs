using UnityEngine;

public class StateMove : StateBase
{
    public StateMove(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("State Move Enter");
        Managers.Game.player.isMoving = true;
    }

    public override void Exit()
    {
        Debug.Log("State Move Exit");
        Managers.Game.player.isMoving = false;
    }
}