using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Manager.UI.SetCanvas(gameObject, true);
    }

    // ClosePopup() 을 내부에서 쉽게 사용할 수 있도록 메소드 상속
    public virtual void ClosePopup()
    {
        Manager.UI.ClosePopup(this);
    }
}
