using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Utill.GetOrAddComponent<T>(go);
    }

    // extension 해주고 싶은 함수 
    // : BindEvent(go, ((PointerEventData data) => { go.transform.position = data.position; }), Define.UIEvent.Drag);
    public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }
}
