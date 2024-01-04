using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/*
 * 씬에 UI오브젝트를 생성하면 생기는 EventSystem가 이벤트를 감지
 *  -> 이벤트를 UI가 캐치(ex, onClick())해서 콜백으로 날려줌
 */

public class UI_EventHandler : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

}
