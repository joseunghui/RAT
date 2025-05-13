using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static Define;

public class Rat : Creature
{
    float _speed = 5;
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

    Vector3 initPosition = Vector3.zero;
    float _jumpProcess = 0;
    float _jumpTime;

    private void Update()
    {
        //Debug.Log($"현재상태 >> {CreatureState}"); 

        if (!Input.anyKey)
            CreatureState = ECreatureState.Idle;

        // 이동 하기
        if (Input.GetKey(KeyCode.A))
        {
            CreatureState = ECreatureState.Move;

            ChangedScaleX(false);
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CreatureState = ECreatureState.Move;

            ChangedScaleX(true);
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }

        // 점프하기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            initPosition = gameObject.transform.position;
            CreatureState = ECreatureState.Jump;
            
            _jumpTime = Ani.GetCurrentAnimatorClipInfo(0).Length; // = 1

            while (_jumpProcess < _jumpTime)
            {
                _jumpProcess += Time.deltaTime;

                if (_jumpProcess < _jumpTime/2)
                {
                    Debug.Log("위로 >> " + _jumpProcess);
                    // 위로
                    gameObject.transform.Translate(Vector3.up * _speed);
                }
                else
                {
                    Debug.Log("아래로 >> " + _jumpProcess);
                    // 아래로
                    gameObject.transform.Translate(Vector3.down * _speed);
                }
                

            }
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
