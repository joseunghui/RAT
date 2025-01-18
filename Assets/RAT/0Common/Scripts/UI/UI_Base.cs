using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // enum을 string 으로 뽑아올 수 있음
        string[] names = Enum.GetNames(type); // string[] 으로 반환됨

        // 생성한 enum 목록을 Unity Obejct로 매핑
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects); // 생성

        // 실제 UI로 만들어주기
        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Utill.FindChild(gameObject, names[i], true); // GameObject 전용 버전
            else
                objects[i] = Utill.FindChild<T>(gameObject, names[i], true); // 여기서 GameObject 자체는 못찾고 컴포넌트만 찾게됨

            // 바인딩 실패한거 로그 찍기
            if (objects[i] == null)
                Debug.Log($"Failed to bind( {names[i]} )");
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;

        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    // 자주 사용하는 컴포넌트(Text, Button, Image)의 value에 바로 접근하게 함수 생성
    // GameObject
    protected GameObject GetGameObject(int idx) { return Get<GameObject>(idx); }
    // Text
    protected TextMeshProUGUI GetText(int idx) { return Get<TextMeshProUGUI>(idx); }
    // Button
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    // Image
    protected Image GetImage(int idx) { return Get<Image>(idx); }


    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Utill.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action; // 혹시 모르니 먼저 빼주기
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action; // 혹시 모르니 먼저 빼주기
                evt.OnDragHandler += action;
                break;

        }

    }
}
