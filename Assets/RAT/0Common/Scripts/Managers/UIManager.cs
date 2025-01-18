using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    // 처음부터 Scene에 넣어둔 Popup까지 처리해주기 위해서
    // 얘는 나중에  UI_Popup에서 보내주기
    int _order = 10; // 기존 오브젝트를 위해 10부터 시작하도록 하기 

    // popup 목록을 들고 있어야 함 > stack 구조가 적당
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _senceUI = null;

    // 중복 코드 빼내기
    public GameObject Root
    {
        get
        {
            // 생성된 오브젝트 들이 한공간에 모여 있게 해주는 Root 오브젝트 우선 생성
            GameObject root = GameObject.Find("UI_Root"); // 먼저 찾고 

            if (root == null) // 없으면 
                root = new GameObject { name = "UI_Root" }; // 만들기

            return root;
        }
    }

    // sort 적용
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Utill.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort) // sorting 이 필요한 경우
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else // sorting 이 필요 없는 경우
        {
            canvas.sortingOrder = 0;
        }
    }

    // Open
    public T ShowScene<T>(string name = null) where T : UI_Scene
        // 보통 오브젝트와 오브젝트에 Add 된 스크립트의 이름이 동일하기 때문에
        // 그냥 오브젝트의 이름으로 스크립트를 가져오게끔 name을 따로 넘기지 않으면 null 처리
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Scene/{name}"); // Scene에 프리팹(GameObject) 생성

        T sceneUI = Utill.GetOrAddComponent<T>(go); // 제너릭 타입의 popup으로 컴포넌트(Component) 생성
        _senceUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return null;
    }

    // Open
    public T ShowPopup<T>(string name = null) where T : UI_Popup
        // 보통 오브젝트와 오브젝트에 Add 된 스크립트의 이름이 동일하기 때문에
        // 그냥 오브젝트의 이름으로 스크립트를 가져오게끔 name을 따로 넘기지 않으면 null 처리
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}"); // Scene에 프리팹(GameObject) 생성

        T popup = Utill.GetOrAddComponent<T>(go); // 제너릭 타입의 popup으로 컴포넌트(Component) 생성

        _popupStack.Push(popup); // 큐에 순차적으로 넣기

        go.transform.SetParent(Root.transform);

        return null;
    }

    // SubItem 전용 Instantiate()
    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/SubItem/{name}");

        // parent 있으면 여기서 아예 SetParent() 까지 해주기
        if (parent != null)
        {
            go.transform.SetParent(parent);
            go.transform.localPosition = parent.localPosition;
            go.transform.localScale = Vector3.one;
        }

        return Utill.GetOrAddComponent<T>(go);
    }

    // 특정 팝업 삭제
    public void ClosePopup(UI_Popup popup)
    {
        // 열려 있는 팝업 없으면 return
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != null)
        {
            Debug.Log("Close Popup Failed!");
        }

        ClosePopup();
    }

    // Close
    public void ClosePopup()
    {
        // 열려 있는 팝업 없으면 return
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop(); // 가장 먼저 위에 있는 팝업 뽑아오기(stack)

        Manager.Resource.Destroy(popup.gameObject); // 씬에서 삭제
        popup = null; // 혹시 모르니 null로 변경까지 해주기

        _order--;
    }

    // Close All
    public void CloseAllPopup()
    {
        // 열려 있는 팝업 없으면 return
        if (_popupStack.Count == 0)
            return;

        while (_popupStack.Count > 0)
        {
            ClosePopup();
        }
    }

    public void Clear()
    {
        CloseAllPopup();
        _senceUI = null;
    }
}
