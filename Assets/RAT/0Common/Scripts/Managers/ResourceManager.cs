using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        // @�ε� ���� �̹� Ǯ�� ��� ������Ʈ���� Ȯ�� 
        if (typeof(T) == typeof(GameObject))
        {
            // @path�� Ȱ���ؼ� ���� ������Ʈ�� �̸� ����
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);
            /*
            GameObject go = Manager.Pool.GetOriginal(name);
            if (go != null) // @�̹� Ǯ�� ��� �ִ� �Ÿ� �ε� ���� �׳� �װ� ��ȯ
                return go as T;*/
        }
        // @Ǯ�� ��� ������ �ε� �� ����
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // ������ �޸𸮿� �ε�(original)
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        /*
         # �̹� Ǯ�� ��(������ ã�� ��ġ�� �� �־���) ������Ʈ��� ������ ����
         
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;*/

        // �ε��� ������ ���纻�� ���� ���� ��ġ(copy)
        GameObject go = Object.Instantiate(original, parent);
        // �����Ǵ� GameObject�� (Clone) �ٴ� �� �����ֱ�
        go.name = original.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        /*
         # �ε��� ���� ������Ʈ �� Ǯ��(����, ���ġ, ��ε�)�� �ʿ��� ģ����� Destroy() ��������
         
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }*/

        Object.Destroy(go);
    }
}
