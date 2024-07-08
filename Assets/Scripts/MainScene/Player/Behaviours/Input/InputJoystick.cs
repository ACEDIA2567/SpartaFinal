using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputJoystick : InputBase
{
    public InputJoystickDown joystickDown;
    public InputJoystickMove joystickMove;

    public InputJoystick()
    {
        joystickDown = new InputJoystickDown();
        joystickMove = new InputJoystickMove();
    }

    protected override void SetBindings()
    {
        return;
    }
}
public class InputJoystickDown : InputBase
{
    public InputJoystickDown() => Init();

    protected override void Init()
    {
        base.Init();
        
        bindingConfig.Add(("MovementJoystick","2DVector"));
        bindingConfig.Add(("Pen","tip"));
        bindingConfig.Add(("Touchscreen","touch*/press"));

        if (inputHandler.data[(int)ActionType.JoystickDown].Action == null)
        {
            action = new InputAction(nameof(ActionType.JoystickDown));
            action.expectedControlType = nameof(Vector2);
        }
        else
        {
            action = inputHandler.data[(int)ActionType.JoystickDown].Action;
        }

        SetBindings();
    }

    protected override void SetBindings()
    {
        bindings = new InputBinding[bindingConfig.Count];
        for (int i = 0; i < bindingConfig.Count; i++)
        {
            bindings[i] = new InputBinding();
            bindings[i].name = bindingConfig[i].name;
            bindings[i].action = action.name;
            if (i == 0) // mother
            {
                bindings[i].path = bindingConfig[i].path;
                bindings[i].isComposite = true;
                bindings[i].isPartOfComposite = false;
            }
            else
            {
                bindings[i].path = $"<{bindingConfig[i].name}>/{bindingConfig[i].path}";
                bindings[i].isComposite = false;
                bindings[i].isPartOfComposite = true;
            }

            action.AddBinding(bindings[i]);
        }
    }
}
public class InputJoystickMove : InputBase
{
    public InputJoystickMove()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        
        bindingConfig.Add(("MovementJoystick","2DVector"));
        bindingConfig.Add(("Pen","position"));
        bindingConfig.Add(("Touchscreen","touch*/position"));

        if (inputHandler.data[(int)ActionType.JoystickMove].Action == null)
        {
            action = new InputAction(nameof(ActionType.JoystickMove));
            action.expectedControlType = nameof(Vector2);
        }
        else
        {
            action = inputHandler.data[(int)ActionType.JoystickDown].Action;
        }

        SetBindings();
    }

    protected override void SetBindings()
    {
        bindings = new InputBinding[bindingConfig.Count];
        for (int i = 0; i < bindingConfig.Count; i++)
        {
            bindings[i] = new InputBinding();
            bindings[i].name = bindingConfig[i].name;
            bindings[i].action = action.name;
            if (i == 0) // mother
            {
                bindings[i].path = bindingConfig[i].path;
                bindings[i].isComposite = true;
                bindings[i].isPartOfComposite = false;
            }
            else
            {
                bindings[i].path = $"<{bindingConfig[i].name}>/{bindingConfig[i].path}";
                bindings[i].isComposite = false;
                bindings[i].isPartOfComposite = true;
            }

            action.AddBinding(bindings[i]);
        }
    }
}
