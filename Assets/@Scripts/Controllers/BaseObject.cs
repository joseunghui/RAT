using UnityEngine;
using static Define;

public class BaseObject : InitBase
{
    public EObjectType ObjectType { get; protected set; } = EObjectType.None;

    // ���� ������ �����ִ��ĸ� ���� (Filp - �⺻�� ���� �ٶ󺸱�)
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

        // TODO Object �� Collider, Animation, Rigid �� GetOrAddComponent ���ֱ�


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
        // TODO ScaleX �� flag �� �������ֱ�
    }

}
