using Unity.VisualScripting;
using UnityEngine;
using static Define;

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
        Rat rat = Managers.Object.Spawn<Rat>(new Vector3Int(0, 0, 0));


        //camera 주시
        CameraController camera = Camera.main.GetOrAddComponent<CameraController>();
        camera.Target = rat;


        return true;
    }

    public override void Clear()
    {

    }
}
