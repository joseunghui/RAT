using Unity.VisualScripting;
using UnityEngine;

public class DevScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        //Rat rat = Managers.Object.Spawn<Rat>(new Vector3Int(-10, 0, 0));


        //camera аж╫ц
        CameraController camera = Camera.main.GetOrAddComponent<CameraController>();
        camera.Target = GameObject.Find("Rat").GetComponent<BaseObject>();


        return true;
    }

    public override void Clear()
    {

    }
}
