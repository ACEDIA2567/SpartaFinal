using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputAttack : InputBehaviour
{
    private void Start()
    {
        Init();
        PlayerInputManager inputManager = GetComponent<PlayerInputManager>();
        inputManager.Inputs[(int)ActionType.Attack].Action = action;
        inputManager.Inputs[(int)ActionType.Attack].Subscribers[InputStatus.Started] += Attack;
        inputManager.SubscribeToggle();
    }

    protected override void Init()
    {
        base.Init();
        bindingConfig.Add(("Defense","rightButton"));
        bindingConfig.Add(("Attack","leftButton"));

        action = new InputAction(nameof(ActionType.Attack), InputActionType.Button);
        action.expectedControlType = nameof(Button);
        

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
//            if (i == 0) // mother binding
//            {
//                bindings[i].path = bindingConfig[i].path;
//                bindings[i].isComposite = true; // is mother?
//                bindings[i].isPartOfComposite = false; // is child?
//            }
//            else
            {
                Debug.Log("Child");
                bindings[i].path = $"<{nameof(InputDevices.Mouse)}>/{bindingConfig[i].path}";
            }
            action.AddBinding(bindings[i]);
        }
    }
    private void Attack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack");
    }
}