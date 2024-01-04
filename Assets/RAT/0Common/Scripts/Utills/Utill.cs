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

    // GameObject 전용 버전
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


        // recursive = 재귀적으로 실행할 건지 여부
        // 자식의 자식 오브젝트까지 찾을건지 (true: 하위의 하위도 찾음. false: 지정한 go 오브젝트만 찾음)
        if (recursive == false)
        {
            // go.transform.GetChild(0); // 0번째 자식만 찾기
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || transform.name == name) // 찾음(빈 값이거나 이름 같은 경우)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            // 유니티 컴포넌트 내장 함수 사용 : GetComponentsInChildren<>()
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name) // 찾음(빈 값이거나 이름 같은 경우)
                {
                    return component;
                }
            }
        }

        return null;
    }
}
