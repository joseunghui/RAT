using UnityEngine;

public class Chapter1Scene : BaseScene
{


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // Map 생성
        GameObject map = Managers.Resource.Instantiate("Chapter1Map");
        map.transform.position = Vector3.zero;
        map.name = "@Chapter1Map";

        // TODO Rat 스폰

        return true;
    }

    public override void Clear()
    {

    }
}
