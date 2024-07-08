using System.Text;
using UnityEngine.InputSystem;

public class InputEvade : InputBase
{
    public InputEvade()
    {
        Init();
        inputHandler.data[(int)ActionType.Evade].Action = action;
        inputHandler.SubscribeToggle();
    }

    protected override void Init()
    {
        base.Init();
        
        bindingConfig.Add(("Evade","Space"));
        
        action = new InputAction(nameof(ActionType.Evade));
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
            bindings[i].path = $"<{nameof(InputDevices.Keyboard)}>/{bindingConfig[i].path}";
            action.AddBinding(bindings[i]);
        }
    }
}