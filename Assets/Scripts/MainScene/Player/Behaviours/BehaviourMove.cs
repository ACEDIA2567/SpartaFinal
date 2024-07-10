using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BehaviourMove : BehaviourInput
{
    [SerializeField] protected float speed;
    protected Rigidbody2D rb2D;
    protected PlayerInputHandler handler;
    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        speed = 5f;
        input = new InputMove();
        stateMachine = Managers.Game.player.StateHandler.stateMachine;
        state = Managers.Game.player.StateHandler.Move;
        action = new UnityAction[(int)InputStatus.Count];
        rb2D = GetComponent<Rigidbody2D>();

        handler = Managers.Game.player.InputHandler;
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Started]   += Started;
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Performed] += Performed;
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Canceled]  += Canceled;
        handler.SubscribeToggle();
    }
    protected override void Started(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(state);
        action[(int)InputStatus.Started]?.Invoke();
    }


    protected override void Performed(InputAction.CallbackContext context)
    {
        // Movement
        rb2D.velocity = speed * context.ReadValue<Vector2>().normalized;
            
        action[(int)InputStatus.Performed]?.Invoke();
    }
    protected override void Canceled(InputAction.CallbackContext context)
    {
        // Stop
        rb2D.velocity = Vector2.zero;
        
        stateMachine.ChangeState(Managers.Game.player.StateHandler.Idle);
        action[(int)InputStatus.Canceled]?.Invoke();
    }
}