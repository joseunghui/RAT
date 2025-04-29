using UnityEngine;

public static class Define
{ 
    public enum EScene
    {
        Unknown,
        TitleScene,
        Chapter1Scene,
        Chapter2Scene,
        Chapter3Scene,

    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum EObjectType
    {
        None,
        Creature,
        Projectile,
        Env,
    }

    public enum ECreatureType
    {
        None,
        Rat,
        Monster,
        Npc,
    }

    public enum ECreatureState
    {
        None,
        Idle,
        Move,
        Jump,
        DoubleJump,
        Attack,
        Dead,
    }

    public enum ESound
    {
        Bgm,
        Effect,
        Max,
    }


    public const int CAMERA_PROJECTION_SIZE = 12;

    public const int RAT_ID = 200000;

    public const int MONSTER_TRAP = 200100;

    public const int ENV_WATER = 300000;


}
