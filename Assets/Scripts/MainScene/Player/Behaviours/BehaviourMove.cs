using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BehaviourMove : BehaviourBase
{
    Rigidbody2D rb2D;
    StateMachine stateMachine;
    public UnityAction moveEvent;
    public UnityAction stopEvent;
    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        input = new InputMove();
        stateMachine = Managers.Game.player.StateHandler.stateMachine;
        state = Managers.Game.player.StateHandler.MoveState;

        rb2D = GetComponent<Rigidbody2D>();
        Managers.Game.player.InputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Performed] += Move;
        Managers.Game.player.InputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Canceled]  += Stop;
    }

    void Move(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(state);
        moveEvent?.Invoke();
    }
    void Stop(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(Managers.Game.player.StateHandler.IdleState);
        stopEvent?.Invoke();
    }
}