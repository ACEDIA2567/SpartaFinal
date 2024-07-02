using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : InputBehaviour
{
    private void Start()
    {
        Init();
        PlayerInputManager inputManager = GetComponent<PlayerInputManager>();
        inputManager.Inputs[(int)ActionType.Move].Action = action;
        inputManager.Inputs[(int)ActionType.Move].Subscribers[InputStatus.Performed] += Movement;
        inputManager.SubscribeToggle();
    }

    protected override void Init()
    {
        base.Init();
        bindingConfig.Add(("Movement","2DVector"));
        bindingConfig.Add(("Up","w"));
        bindingConfig.Add(("Down","s"));
        bindingConfig.Add(("Left","a"));
        bindingConfig.Add(("Right","d"));

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
            else
            {
                bindings[i].path = $"<{nameof(InputDevices.Keyboard)}>/{bindingConfig[i].path}";
                bindings[i].isComposite = false;
                bindings[i].isPartOfComposite = true;
            }

            action.AddBinding(bindings[i]);
        }
    }
    private void Movement(InputAction.CallbackContext obj)
    {
        Debug.Log("Movement");
    }
}