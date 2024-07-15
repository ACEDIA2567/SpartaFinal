using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BehaviourJoystick : BehaviourMove
{
    PointerEventData eventData;
    List<RaycastResult> raycastResults;
//    UIInputStick joystick;

    JoystickMode controlMode;
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        
        input = new InputJoystick();
        controlMode = JoystickMode.Fixed;
        eventData = new PointerEventData(EventSystem.current);
        
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Started]   += OnPointerDown;
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Performed] += OnPointerMove;
        handler.data[(int)ActionType.Move].Subscribers[InputStatus.Canceled]  += OnPointerUp;
    }

    void OnPointerDown(InputAction.CallbackContext context)
    {
        Debug.Log(EventSystem.current);
        if (EventSystem.current == null ||
            context.control?.device is not Pointer)
            return;
        
        Vector2 screenPosition = Vector2.zero;
        if (context.control?.device is Pointer pointer)
            screenPosition = pointer.position.ReadValue();
        eventData.position = screenPosition;
        EventSystem.current.RaycastAll(eventData,raycastResults);
        if (raycastResults.Count == 0)
            return;

        bool stickActive = false;
        foreach (var result in raycastResults)
        {
            if (result.gameObject != gameObject) continue;
            stickActive = true;
            break;
        }

        if (!stickActive) return;

//        BeginInteraction(screenPosition, Util.GetCameraFromCanvas(joystick.canv));
    }
    
    void OnPointerMove(InputAction.CallbackContext obj)
    {
        // character movement have to be written here,
        Debug.Assert(obj.control?.device is Pointer);

        Vector2 screenPosition = ((Pointer)obj.control.device).position.ReadValue();

//        Vector2 dir = (screenPosition - (Vector2)joystick.transform.position);
//        MoveStick(screenPosition, Util.GetCameraFromCanvas(joystick.canv));
    }

    void OnPointerUp(InputAction.CallbackContext obj)
    {
        EndInteraction();
    }

    void BeginInteraction(Vector2 screenPosition, Camera getCameraFromCanvas)
    {
//        RectTransform canvasRect = joystick.canv.GetComponent<RectTransform>();
//        if (canvasRect == null)
        {
            Debug.LogError("BeginInteraction");
            return;
            
        }
        
    }

    void MoveStick(Vector2 screenPosition, Camera getCameraFromCanvas)
    {
        throw new NotImplementedException();
    }

    void EndInteraction()
    {
        throw new NotImplementedException();
    }
}