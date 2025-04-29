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

    // Object�� �������� ������� �����ϸ� �� (Item, Creature, NPC ��)
    public int DataTemplateID { get; set; }

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

        // Object �� Collider, Animation, Rigid �� GetOrAddComponent ���ֱ�
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

        // TODO Flip ����
    }

}
