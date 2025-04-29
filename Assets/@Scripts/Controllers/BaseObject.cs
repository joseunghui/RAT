using UnityEngine;
using UnityEngine.Rendering;
using static Define;

public class BaseObject : InitBase
{
    public EObjectType ObjectType { get; protected set; } = EObjectType.None;
    public CircleCollider2D Collider { get; private set; }
    public Animator Ani { get; private set; }
    public Rigidbody2D RigidBody { get; private set; }

    public float ColliderRadius { get { return Collider != null ? Collider.radius : 0.0f; } }
    public Vector3 CenterPosition { get { return transform.position + Vector3.up * ColliderRadius; } }

    // Object의 포괄적인 종류라고 생각하면 됨 (Item, Creature, NPC 등)
    public int DataTemplateID { get; set; }

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

        // Object 의 Collider, Animation, Rigid 등 GetOrAddComponent 해주기
        Collider = gameObject.GetOrAddComponent<CircleCollider2D>();
        Ani = GetComponent<Animator>();
        RigidBody = GetComponent<Rigidbody2D>();

        return true;
    }

    #region Battle
    public virtual void OnDamaged(BaseObject attacker)
    {

    }

    public virtual void OnDead(BaseObject attacker)
    {

    }


    #endregion

    #region Animation
    protected virtual void SetLayerSorting(int sortingOrder)
    {
        SortingGroup sg = Utils.GetOrAddComponent<SortingGroup>(gameObject);
        sg.sortingOrder = sortingOrder;
    }

    protected virtual void UpdateAnimation()
    {

    }

    public void PlayAnimation(ECreatureType type, ECreatureState creatureState, bool loop)
    {
        if (Ani == null)
            return;

        
    }

    public void SetRigidBodyVelocity(Vector2 velocity)
    {
        if (RigidBody == null)
            return;

        RigidBody.linearVelocity = velocity;

        if (velocity.x < 0)
            LookLeft = true;
        else if (velocity.x > 0)
            LookLeft = false;
    }
    #endregion

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
        if (Ani == null)
            return;

        // TODO Flip 설정
    }

}
