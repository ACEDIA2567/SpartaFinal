using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class UIInputStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public AxisOptions axisOptions { get; set; }
    public float HandleRange { get; set; }
    public float DeadZone { get; set; }
    public float moveThres = 1f;

    Vector2 defaultPos;
    Vector2 dir;
    Vector2 input;

    RectTransform bg;
    RectTransform handle;
    public Canvas canv;
    Camera cam;

    void Start()
    {
        Init();
    }

    void Init()
    {
        canv = GetComponentInParent<Canvas>();
        cam = Camera.main;
        
        HandleRange = 1f;
        DeadZone = 0;
        AxisOptions axisOptions = AxisOptions.Both;
        bg.pivot                = new Vector2(0.5f, 0.5f);
        handle.anchorMin        = new Vector2(0.5f, 0.5f);
        handle.anchorMax        = new Vector2(0.5f, 0.5f);
        handle.pivot            = new Vector2(0.5f, 0.5f);
        handle.anchoredPosition = Vector2.zero;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = RectTransformUtility.WorldToScreenPoint(cam, bg.position);
        Vector2 rad = bg.sizeDelta / 2;
        input = (eventData.position - pos) / (rad * canv.scaleFactor);
//        FormatInput();
//        HandleInput()

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    //    private PlayerInputHandler _inputHandler;
//    [SerializeField] private float rangeLimitation;
//    private Vector3 defaultPosition;
//
//    private void Start()
//    {
//        Init();
//        defaultPosition = transform.position;
//    }
//
//    void Init()
//    {
//        _inputHandler = GameObject.FindWithTag(nameof(Tags.Player)).GetComponent<PlayerInputHandler>();
//        _inputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Performed] += Move;
//        _inputHandler.data[(int)ActionType.Move].Subscribers[InputStatus.Canceled] += Stop;
//    }
//
//    private void Move(InputAction.CallbackContext obj)
//    {
//        transform.position = defaultPosition + rangeLimitation * obj.ReadValue<Vector3>();
//    }
//
//    private void Stop(InputAction.CallbackContext obj)
//    {
//        transform.position = defaultPosition;
//    }
}
