using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        // @로드 전에 이미 풀링 대상 오브젝트인지 확인 
        if (typeof(T) == typeof(GameObject))
        {
            // @path를 활용해서 게임 오브젝트의 이름 추출
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);
            /*
            GameObject go = Manager.Pool.GetOriginal(name);
            if (go != null) // @이미 풀링 대상에 있는 거면 로드 없이 그냥 그거 반환
                return go as T;*/
        }
        // @풀링 대상에 없으면 로드 후 리턴
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 원본을 메모리에 로드(original)
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        /*
         # 이미 풀링 된(원본을 찾아 배치된 적 있었던) 오브젝트라면 재사용을 하자
         
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;*/

        // 로드한 원본의 복사본을 만들어서 씬에 배치(copy)
        GameObject go = Object.Instantiate(original, parent);
        // 생성되는 GameObject에 (Clone) 붙는 거 없애주기
        go.name = original.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        /*
         # 로드한 게임 오브젝트 중 풀링(재사용, 재배치, 재로드)이 필요한 친구라면 Destroy() 하지말자
         
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }*/

        Object.Destroy(go);
    }
}
