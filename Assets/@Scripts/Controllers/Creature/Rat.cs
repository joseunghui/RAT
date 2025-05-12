using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static Define;

public class Rat : Creature
{
    [SerializeField]
    float _speed = 50000;

    float filp = 1;

    public override ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            if (_creatureState != value)
            {
                base.CreatureState = value;

                switch (_creatureState)
                {
                    case ECreatureState.None:
                        break;
                    case ECreatureState.Idle:
                        Ani.CrossFade("rat_idle", 0.1f);
                        break;
                    case ECreatureState.Move:
                        Ani.CrossFade("rat_run", 0.1f);
                        break;
                    case ECreatureState.Attack:
                        Ani.CrossFade("rat_attack", 0.3f);
                        break;
                    case ECreatureState.Jump:
                        Ani.CrossFade("rat_jump", 0.1f);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Rat;
           
        Managers.Game.OnCreatureStateChanged -= HandleOnCreatureStateChanged;
        Managers.Game.OnCreatureStateChanged += HandleOnCreatureStateChanged;

        //Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
        //Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;

        return true;
    }

    private void Update()
    {
        Debug.Log($"현재상태 >> {CreatureState}"); 

        if (!Input.anyKey)
            CreatureState = ECreatureState.Idle;

        // 이동 하기
        if (Input.GetKey(KeyCode.A))
        {
            CreatureState = ECreatureState.Move;

            ChangedScaleX(false);
            gameObject.transform.parent.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CreatureState = ECreatureState.Move;

            ChangedScaleX(true);
            gameObject.transform.parent.Translate(Vector3.right * Time.deltaTime);
        }

        // 점프하기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatureState = ECreatureState.Jump;
        }

    }



    public override void SetInfo(int templateID)
    {
        base.SetInfo(templateID);

        // State
        CreatureState = ECreatureState.Idle;
    }


    private void HandleOnCreatureStateChanged(ECreatureState state)
    {
        Debug.Log("HandleOnCreatureStateChanged");


    }

    void ChangedScaleX(bool IsFront)
    {
        Vector3 scale = gameObject.transform.localScale;

        if (IsFront)
            filp = scale.x < 0 ? scale.x * (-1) : scale.x;
        else
            filp = scale.x > 0 ? scale.x * (-1) : scale.x;

        gameObject.transform.localScale = new Vector3(filp, scale.y, scale.z);
        
    }


}
