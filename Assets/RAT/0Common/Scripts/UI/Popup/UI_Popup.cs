using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Manager.UI.SetCanvas(gameObject, true);
    }

    // ClosePopup() �� ���ο��� ���� ����� �� �ֵ��� �޼ҵ� ���
    public virtual void ClosePopup()
    {
        Manager.UI.ClosePopup(this);
    }
}
