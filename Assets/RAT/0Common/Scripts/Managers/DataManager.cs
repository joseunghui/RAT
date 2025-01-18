using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDictInSeq();
}
public class DataManager
{

    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();

    public void init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDictInSeq();
        Debug.Log($"Stat 데이터 {StatDict.Count}개 로딩성공!");
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Manager.Resource.Load<TextAsset>($"Data/{path}");

        return JsonUtility.FromJson<Loader>(textAsset.text);

    }
}
