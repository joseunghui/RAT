using UnityEngine;
using static Define;

public class Rat : Creature
{
    public override ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            if (_creatureState != value)
            {
                base.CreatureState = value;

                if (value == ECreatureState.Move)
                    RigidBody.mass = CreatureData.Mass;
                else
                    RigidBody.mass = CreatureData.Mass * 0.1f;
            }
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Rat;

        return true;
    }

    public override void SetInfo(int templateID)
    {
        base.SetInfo(templateID);

        // State
        CreatureState = ECreatureState.Idle;
    }
}
