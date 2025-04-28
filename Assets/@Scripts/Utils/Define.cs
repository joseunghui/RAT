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

}
