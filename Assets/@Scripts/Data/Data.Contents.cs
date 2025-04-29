using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Data
{

    #region CreatureData
    [Serializable]
    public class CreatureData
    {
        public int DataId;
        public string DescriptionTextID;
        public string PrefabLabel;
        public float ColliderOffsetX;
        public float ColliderOffstY;
        public float ColliderRadius;
        public float Mass;
        public float MaxHp;
        public float Atk;
        public float AtkRange;
        public float MoveSpeed;
        public string AnimatorName;
        public int DropItemId;
    }

    [Serializable]
    public class CreatureDataLoader : ILoader<int, CreatureData>
    {
        public List<CreatureData> creatures = new List<CreatureData>();

        public Dictionary<int, CreatureData> MakeDict()
        {
            Dictionary<int, CreatureData> dict = new Dictionary<int, CreatureData>();
            foreach (CreatureData creature in creatures)
                dict.Add(creature.DataId, creature);
            return dict;
        }
    }
    #endregion
}