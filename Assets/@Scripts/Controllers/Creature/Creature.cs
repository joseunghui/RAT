using UnityEngine;
using static Define;

public class Creature : BaseObject
{
    /**
     * CreatureData �� ������� �����ϰ� ��
     */
    public Data.CreatureData CreatureData { get; private set; }
    public ECreatureType CreatureType { get; protected set; } = ECreatureType.None;

    #region Stats
    public float Hp { get; set; }
    public float MaxHp { get; set; }
    public float Atk { get; set; }
    public float MoveSpeed { get; set; }
    #endregion


    protected ECreatureState _creatureState = ECreatureState.None;
    public virtual ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            if (_creatureState != value)
            {
                // ���°� ���� �Ǵ� ��� �ִϸ��̼� ���� ���
                // Creature�� ���¿� Spine �ִϸ��̼��� �Բ� �����Ǿ�� ��!
                _creatureState = value;
                UpdateAnimation();
            }
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // �ʱ�ȭ
        ObjectType = EObjectType.Creature;

        return true;
    }

    public virtual void SetInfo(int templateID)
    {
        // ���� �����ͽ�Ʈ�� ID�� �����ͼ� ���
        DataTemplateID = templateID;

        CreatureData = Managers.Data.CreatureDic[templateID];

        gameObject.name = $"{CreatureData.DataId}_{CreatureData.DescriptionTextID}";

        // Collider (�浹 �ֱ�)
        //Collider.offset = new Vector2(CreatureData.ColliderOffsetX, CreatureData.ColliderOffstY);
        //Collider.radius = CreatureData.ColliderRadius;


        // RigidBody (���� �޾ƿ���)
        RigidBody.mass = CreatureData.Mass;

        // Animation �������ֱ� 


        // Stat
        Hp = CreatureData.MaxHp;
        MaxHp = CreatureData.MaxHp;
        Atk = CreatureData.Atk;
        MoveSpeed = CreatureData.MoveSpeed;


        // State
        CreatureState = ECreatureState.Idle;
    }

}
