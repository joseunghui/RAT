using System;
using UnityEngine;

public class GameManagerEX
{
    private Vector2 _moveDir;
    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value;
            OnMoveDirChanged?.Invoke(value);
        }
    }

    private Define.ECreatureState _creatureState;
    
    public Define.ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            _creatureState = value;
            OnCreatureStateChanged?.Invoke(_creatureState);
        }
    }

    #region Action
    public event Action<Vector2> OnMoveDirChanged;
    public event Action<Define.ECreatureState> OnCreatureStateChanged;
    #endregion
}
