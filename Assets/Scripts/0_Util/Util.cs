using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T comp = go.GetComponent<T>();
        if(comp == null)
            comp = go.AddComponent<T>();
        return comp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="name">오브젝트의 이름 확인 + 이름 안 적으면 그냥 오브젝트임만 확인</param>
    /// <param name="recursive">재귀적으로 찾을 것인가 : 자식의 자식까지 확인할 것인가</param>
    /// <returns></returns>
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

    /// <summary>
    /// T FindChild<T>와 같이 오브젝트를 찾지만 컴포넌트 없이 게임오브젝트만 찾는 함수
    /// </summary>
    /// <param name="go"></param>
    /// <param name="name"></param>
    /// <param name="recursive"></param>
    /// <returns></returns>
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform tf = FindChild<Transform>(go, name, recursive);

        if (tf == null)
            return null;

        return tf.gameObject;
    }
}
