using UnityEngine;

public class Util
{
    public static Camera GetCameraFromCanvas(Canvas canvas)
    {
        RenderMode mode = canvas.renderMode;
        if (mode == RenderMode.ScreenSpaceOverlay ||
            (mode == RenderMode.ScreenSpaceCamera &&
             canvas.worldCamera == null))
            return null;

        return canvas.worldCamera ?? Camera.main;
    }
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T comp = go.GetComponent<T>();
        if(comp == null)
            comp = go.AddComponent<T>();
        return comp;
    }

    public static GameObject FindChild(GameObject go, string name = null)
    {
        Transform tf = FindChild<Transform>(go, name);
        if (tf == null)
            return null;

        return tf.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : Object
    {
        if(go==null) return null;

        if(recursive == false)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T comp = transform.GetComponent<T>();
                    if(comp != null)
                        return comp;
                }
            }
        }
        else
        {
            foreach (T comp in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || comp.name == name)
                    return comp;
            }
        }

        return null;
    }
}
