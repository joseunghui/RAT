using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    // ó������ Scene�� �־�� Popup���� ó�����ֱ� ���ؼ�
    // ��� ���߿�  UI_Popup���� �����ֱ�
    int _order = 10; // ���� ������Ʈ�� ���� 10���� �����ϵ��� �ϱ� 

    // popup ����� ��� �־�� �� > stack ������ ����
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _senceUI = null;

    // �ߺ� �ڵ� ������
    public GameObject Root
    {
        get
        {
            // ������ ������Ʈ ���� �Ѱ����� �� �ְ� ���ִ� Root ������Ʈ �켱 ����
            GameObject root = GameObject.Find("UI_Root"); // ���� ã�� 

            if (root == null) // ������ 
                root = new GameObject { name = "UI_Root" }; // �����

            return root;
        }
    }

    // sort ����
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Utill.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort) // sorting �� �ʿ��� ���
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else // sorting �� �ʿ� ���� ���
        {
            canvas.sortingOrder = 0;
        }
    }

    // Open
    public T ShowScene<T>(string name = null) where T : UI_Scene
        // ���� ������Ʈ�� ������Ʈ�� Add �� ��ũ��Ʈ�� �̸��� �����ϱ� ������
        // �׳� ������Ʈ�� �̸����� ��ũ��Ʈ�� �������Բ� name�� ���� �ѱ��� ������ null ó��
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Scene/{name}"); // Scene�� ������(GameObject) ����

        T sceneUI = Utill.GetOrAddComponent<T>(go); // ���ʸ� Ÿ���� popup���� ������Ʈ(Component) ����
        _senceUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return null;
    }

    // Open
    public T ShowPopup<T>(string name = null) where T : UI_Popup
        // ���� ������Ʈ�� ������Ʈ�� Add �� ��ũ��Ʈ�� �̸��� �����ϱ� ������
        // �׳� ������Ʈ�� �̸����� ��ũ��Ʈ�� �������Բ� name�� ���� �ѱ��� ������ null ó��
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}"); // Scene�� ������(GameObject) ����

        T popup = Utill.GetOrAddComponent<T>(go); // ���ʸ� Ÿ���� popup���� ������Ʈ(Component) ����

        _popupStack.Push(popup); // ť�� ���������� �ֱ�

        go.transform.SetParent(Root.transform);

        return null;
    }

    // SubItem ���� Instantiate()
    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/SubItem/{name}");

        // parent ������ ���⼭ �ƿ� SetParent() ���� ���ֱ�
        if (parent != null)
        {
            go.transform.SetParent(parent);
            go.transform.localPosition = parent.localPosition;
            go.transform.localScale = Vector3.one;
        }

        return Utill.GetOrAddComponent<T>(go);
    }

    // Ư�� �˾� ����
    public void ClosePopup(UI_Popup popup)
    {
        // ���� �ִ� �˾� ������ return
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
        // ���� �ִ� �˾� ������ return
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop(); // ���� ���� ���� �ִ� �˾� �̾ƿ���(stack)

        Manager.Resource.Destroy(popup.gameObject); // ������ ����
        popup = null; // Ȥ�� �𸣴� null�� ������� ���ֱ�

        _order--;
    }

    // Close All
    public void CloseAllPopup()
    {
        // ���� �ִ� �˾� ������ return
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
