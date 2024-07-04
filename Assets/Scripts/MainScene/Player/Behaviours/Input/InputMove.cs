using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove : InputBase
{
//    private Rigidbody2D rb2D;
    [SerializeField] float speed;

    public InputMove()
    {
        Init();
        PlayerInputHandler inputHandler = Managers.Game.player.InputHandler;
        inputHandler.data[(int)ActionType.Move].Action = action;
//        inputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Performed] += Movement;
//        inputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Canceled]  += Stop;
        inputHandler.SubscribeToggle();
    }

    protected override void Init()
    {
        base.Init();

//        rb2D = Managers.Game.player.GetComponent<Rigidbody2D>();
        
        bindingConfig.Add(("Movement","2DVector"));
        bindingConfig.Add(("Up","w"));
        bindingConfig.Add(("Down","s"));
        bindingConfig.Add(("Left","a"));
        bindingConfig.Add(("Right","d"));
        bindingConfig.Add(("Left Stick","leftStick"));

        action = new InputAction(nameof(ActionType.Move), InputActionType.Value);
        action.expectedControlType = nameof(Vector2);

        bindings = new InputBinding[bindingConfig.Count];
        SetBindings();

    }

    protected override void SetBindings()
    {
        for (int i = 0; i < bindingConfig.Count; i++)
        {
            bindings[i] = new InputBinding();
            bindings[i].name = bindingConfig[i].name;
            bindings[i].action = action.name;
            
            if (i == 0) // mother bind
            {
                bindings[i].path = bindingConfig[i].path;
                bindings[i].isComposite = true; // is mother?
                bindings[i].isPartOfComposite = false; // is child?
            }
            else if (bindingConfig[i].name.Contains("Stick"))
            {
                bindings[i].path = $"<{nameof(InputDevices.Gamepad)}>/{bindingConfig[i].path}";
                bindings[i].isComposite = false;
                bindings[i].isPartOfComposite = true;
            }
            else
            {
                bindings[i].path = $"<{nameof(InputDevices.Keyboard)}>/{bindingConfig[i].path}";
                bindings[i].isComposite = false;
                bindings[i].isPartOfComposite = true;
            }

            action.AddBinding(bindings[i]);
        }
    }

//    private void Movement(InputAction.CallbackContext obj)
//    {
//        // Dont use `Time.deltaTime`
//        // rb2D.velocity = speed * Time.deltaTime * obj.ReadValue<Vector2>().normalized;
//        // rb2D.velocity = speed * Time.fixedDeltaTime * obj.ReadValue<Vector2>().normalized;
//        rb2D.velocity = speed * obj.ReadValue<Vector2>().normalized;
//    }
//
//    private void Stop(InputAction.CallbackContext obj)
//    {
//        rb2D.velocity = Vector2.zero;
//    }
}