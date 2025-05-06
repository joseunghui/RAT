using UnityEngine;
using static Define;

public class Creature : BaseObject
{
    /**
     * CreatureData 를 기반으로 관리하게 됨
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
                // 상태가 변경 되는 경우 애니메이션 또한 재생
                // Creature의 상태와 Spine 애니메이션은 함께 관리되어야 함!
                _creatureState = value;
                UpdateAnimation();
            }
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // 초기화
        ObjectType = EObjectType.Creature;

        return true;
    }

    public virtual void SetInfo(int templateID)
    {
        // 현재 데이터시트의 ID를 가져와서 사용
        DataTemplateID = templateID;

        CreatureData = Managers.Data.CreatureDic[templateID];

        gameObject.name = $"{CreatureData.DataId}_{CreatureData.DescriptionTextID}";

        // Collider (충돌 넣기)
        //Collider.offset = new Vector2(CreatureData.ColliderOffsetX, CreatureData.ColliderOffstY);
        //Collider.radius = CreatureData.ColliderRadius;


        // RigidBody (질량 받아오기)
        RigidBody.mass = CreatureData.Mass;

        // Animation 설정해주기 


        // Stat
        Hp = CreatureData.MaxHp;
        MaxHp = CreatureData.MaxHp;
        Atk = CreatureData.Atk;
        MoveSpeed = CreatureData.MoveSpeed;


        // State
        CreatureState = ECreatureState.Idle;
    }

}
