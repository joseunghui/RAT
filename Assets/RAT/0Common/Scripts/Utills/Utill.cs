using UnityEngine;

public class Utill
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();

        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }

    // GameObject ���� ����
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);

        if (transform == null)
            return null;

        return transform.gameObject;
    }


    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;


        // recursive = ��������� ������ ���� ����
        // �ڽ��� �ڽ� ������Ʈ���� ã������ (true: ������ ������ ã��. false: ������ go ������Ʈ�� ã��)
        if (recursive == false)
        {
            // go.transform.GetChild(0); // 0��° �ڽĸ� ã��
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || transform.name == name) // ã��(�� ���̰ų� �̸� ���� ���)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            // ����Ƽ ������Ʈ ���� �Լ� ��� : GetComponentsInChildren<>()
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name) // ã��(�� ���̰ų� �̸� ���� ���)
                {
                    return component;
                }
            }
        }

        return null;
    }
}
