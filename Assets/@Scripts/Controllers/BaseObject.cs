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



}
