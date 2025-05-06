using System;
using UnityEngine;
using UnityEngine.UIElements;
using static Define;

public class Rat : Creature
{
    [SerializeField]
    float _speed = 50000;

    public override ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            if (_creatureState != value)
            {
                base.CreatureState = value;

                
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

        // 이동 하기
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            gameObject.transform.TranslateEx(new Vector3Int(5, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
           
        }

    }



    public override void SetInfo(int templateID)
    {
        base.SetInfo(templateID);

        // State
        CreatureState = ECreatureState.Idle;
    }


    private void HandleOnMoveDirChanged(Vector2 moveDir)
    {
        
    }


    private void HandleOnCreatureStateChanged(ECreatureState state)
    {
        switch (state)
        {
            case ECreatureState.Idle:
                CreatureState = ECreatureState.Idle;
                break;
            case ECreatureState.Move:
                CreatureState = ECreatureState.Move;
                break;
            default:
                break;
        }
    }
}
