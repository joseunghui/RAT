using System;
using System.Collections.Generic;
using UnityEngine;

#region Stat
[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    /**
     * 형식 정리
     * MakeDictInSeq() : Dictionary<int, Stat>
     */
    public Dictionary<int, Stat> MakeDictInSeq()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();

        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);

        return dict;
    }
}
#endregion