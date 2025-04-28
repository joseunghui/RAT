using UnityEngine;
using static Define;

public class BaseObject : InitBase
{
    public EObjectType ObjectType { get; protected set; } = EObjectType.None;

    // 내가 왼쪽을 보고있느냐를 관리 (Filp - 기본이 왼쪽 바라보기)
    bool _lookLeft = true;
    public bool LookLeft
    {
        get { return _lookLeft; }
        set
        {
            _lookLeft = value;
            Flip(!value);
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // TODO Object 의 Collider, Animation, Rigid 등 GetOrAddComponent 해주기


        return true;
    }

    public void TranslateEx(Vector3 dir)
    {
        transform.Translate(dir);

        if (dir.x < 0)
            LookLeft = true;
        else if (dir.x > 0)
            LookLeft = false;
    }

    public void Flip(bool flag)
    {
        // TODO ScaleX 의 flag 값 설정해주기
    }

}
