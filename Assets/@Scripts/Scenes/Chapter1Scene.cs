using UnityEngine;

public class Chapter1Scene : BaseScene
{


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // Map ����
        GameObject map = Managers.Resource.Instantiate("Chapter1Map");
        map.transform.position = Vector3.zero;
        map.name = "@Chapter1Map";

        // TODO Rat ����

        return true;
    }

    public override void Clear()
    {

    }
}
