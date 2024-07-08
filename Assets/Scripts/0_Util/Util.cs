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
    /// <param name="name">������Ʈ�� �̸� Ȯ�� + �̸� �� ������ �׳� ������Ʈ�Ӹ� Ȯ��</param>
    /// <param name="recursive">��������� ã�� ���ΰ� : �ڽ��� �ڽı��� Ȯ���� ���ΰ�</param>
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
    /// T FindChild<T>�� ���� ������Ʈ�� ã���� ������Ʈ ���� ���ӿ�����Ʈ�� ã�� �Լ�
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
