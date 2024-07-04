using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

public abstract class UIBase : MonoBehaviour
{
    protected Dictionary<Type, Object[]> _objects = new Dictionary<Type, Object[]>();

    public abstract void Init();

    void Start()
    {
        Init();
        Managers.UI.UIlist.Add(this);
    }

    protected void Bind<T>(Type type) where T : Object
    {
        string[] names = Enum.GetNames(type);
        Object[] objects = new Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UIEventHandler evt = Util.GetOrAddComponent<UIEventHandler>(go);

        evt.OnPointerHandler[(int)type] -= action;
        evt.OnPointerHandler[(int)type] += action;
    }
}

public class UIEventHandler : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    public Action<PointerEventData>[] OnPointerHandler = new Action<PointerEventData>[6] { null, null, null, null, null, null };
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.Click] != null)
            OnPointerHandler[(int)Define.UIEvent.Click].Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.PointerDown] != null)
            OnPointerHandler[(int)Define.UIEvent.PointerDown].Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.PointerUp] != null)
            OnPointerHandler[(int)Define.UIEvent.PointerUp].Invoke(eventData);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.BeginDrag] != null)
            OnPointerHandler[(int)Define.UIEvent.BeginDrag].Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.Drag] != null)
            OnPointerHandler[(int)Define.UIEvent.Drag].Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnPointerHandler[(int)Define.UIEvent.EndDrag] != null)
            OnPointerHandler[(int)Define.UIEvent.EndDrag].Invoke(eventData);
    }

}
