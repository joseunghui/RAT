using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/*
 * ���� UI������Ʈ�� �����ϸ� ����� EventSystem�� �̺�Ʈ�� ����
 *  -> �̺�Ʈ�� UI�� ĳġ(ex, onClick())�ؼ� �ݹ����� ������
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
