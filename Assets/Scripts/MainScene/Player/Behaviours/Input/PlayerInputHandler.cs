using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerInputHandler
{
    public InputData[] data;

    public PlayerInputHandler()
    {
        Managers.Game.player.InputHandler = this;
        Init();
    }

    void Init()
    {
        data = new InputData[(int)ActionType.Count];
       
        for(int i=0; i<(int)ActionType.Count; i++)
        {
            data[i] = new InputData();
            data[i].Subscribers = new Dictionary<InputStatus, Action<InputAction.CallbackContext>>
            {
                { InputStatus.Started, null },
                { InputStatus.Performed, null },
                { InputStatus.Canceled, null }
            };
        }
        SubscribeToggle();
    }

    void OnEnable()
    {
        SubscribeToggle();
    }

    void OnDisable()
    {
        SubscribeToggle(false);
    }

    public void SubscribeToggle(bool opt = true)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (opt)
            {
                if (data[i].Subscribers[InputStatus.Started] != null)
                {
                    data[i].Action.started   -= data[i].Subscribers[InputStatus.Started];
                    data[i].Action.started   += data[i].Subscribers[InputStatus.Started];
                }
                if (data[i].Subscribers[InputStatus.Performed] != null)
                {
                    data[i].Action.performed -= data[i].Subscribers[InputStatus.Performed];
                    data[i].Action.performed += data[i].Subscribers[InputStatus.Performed];
                }
                if (data[i].Subscribers[InputStatus.Canceled] != null)
                {
                    data[i].Action.canceled  -= data[i].Subscribers[InputStatus.Canceled];
                    data[i].Action.canceled  += data[i].Subscribers[InputStatus.Canceled];
                }
                if(data[i].Action != null)
                    data[i].Action.Enable();
            }
            else
            {
                if (data[i].Subscribers[InputStatus.Started] != null)
                    data[i].Action.started   -= data[i].Subscribers[InputStatus.Started];
                if (data[i].Subscribers[InputStatus.Performed] != null)
                    data[i].Action.performed -= data[i].Subscribers[InputStatus.Performed];
                if (data[i].Subscribers[InputStatus.Canceled] != null)
                    data[i].Action.canceled  -= data[i].Subscribers[InputStatus.Canceled];
                if(data[i].Action != null)
                    data[i].Action.Disable();
            }
        }
    }
}

[Serializable]
public class InputData
{
    public InputAction Action;
    public Dictionary<InputStatus, Action<InputAction.CallbackContext>> Subscribers;
}