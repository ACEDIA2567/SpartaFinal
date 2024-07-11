using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BehaviourAttack : BehaviourInput
{
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        input = new InputAttack();
        stateMachine = Managers.Game.player.StateHandler.stateMachine;
        state = Managers.Game.player.StateHandler.GetState(ActionType.Attack);
        action = new UnityAction[(int)InputStatus.Count];

        PlayerInputHandler handler = Managers.Game.player.InputHandler;
        handler.data[(int)ActionType.Attack].Subscribers[InputStatus.Started]   += Started;
        handler.data[(int)ActionType.Attack].Subscribers[InputStatus.Performed] += Performed;
        handler.data[(int)ActionType.Attack].Subscribers[InputStatus.Canceled]  += Canceled;
        handler.SubscribeToggle();
    }

    protected override void Started(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(state);
        action[(int)InputStatus.Started]?.Invoke();
    }

    protected override void Performed(InputAction.CallbackContext context)
    {
        action[(int)InputStatus.Performed]?.Invoke();
    }

    protected override void Canceled(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.previousState);
        action[(int)InputStatus.Canceled]?.Invoke();
    }
}