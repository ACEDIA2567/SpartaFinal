using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerInputManager : MonoBehaviour
{
    public InputAndBehaviour[] Inputs;

    void Awake()
    {
        Init();
    }

    void Init()
    {
//        if(Inputs.Length == 0)
        Inputs = new InputAndBehaviour[(int)ActionType.Count];
       
        for(int i=0; i<(int)ActionType.Count; i++)
        {
            Inputs[i] = new InputAndBehaviour();
            Inputs[i].Subscribers = new Dictionary<InputStatus, Action<InputAction.CallbackContext>>
            {
                { InputStatus.Started, null },
                { InputStatus.Performed, null },
                { InputStatus.Canceled, null }
            };
        }
        SubscribeToggle();
    }

    public void SubscribeToggle(bool opt = true)
    {
        for (int i = 0; i < Inputs.Length; i++)
        {
            if (opt)
            {
                if (Inputs[i].Subscribers[InputStatus.Started] != null)
                {
                    Inputs[i].Action.started   -= Inputs[i].Subscribers[InputStatus.Started];
                    Inputs[i].Action.started   += Inputs[i].Subscribers[InputStatus.Started];
                }
                if (Inputs[i].Subscribers[InputStatus.Performed] != null)
                {
                    Inputs[i].Action.performed -= Inputs[i].Subscribers[InputStatus.Performed];
                    Inputs[i].Action.performed += Inputs[i].Subscribers[InputStatus.Performed];
                }
                if (Inputs[i].Subscribers[InputStatus.Canceled] != null)
                {
                    Inputs[i].Action.canceled  -= Inputs[i].Subscribers[InputStatus.Canceled];
                    Inputs[i].Action.canceled  += Inputs[i].Subscribers[InputStatus.Canceled];
                }
                if(Inputs[i].Action != null)
                    Inputs[i].Action.Enable();
            }
            else
            {
                Inputs[i].Action.Disable();
            }
        }
    }
}

[Serializable]
public class InputAndBehaviour
{
    public InputAction Action;
    public Dictionary<InputStatus, Action<InputAction.CallbackContext>> Subscribers;
}