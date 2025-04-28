using UnityEngine;

public class UI_SubItem : UI_Base
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // TODO : UIManager 에 SubItem 전용 함수 만들기

        return true;
    }
}
