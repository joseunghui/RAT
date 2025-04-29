using Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;


// �������� ������ �� �ִ� Key ���� Generic���� ������ֱ� (ã�� ���ϵ���)
public interface ILoader<Key, Value> 
{
    Dictionary<Key, Value> MakeDict();
}


public class DataManager
{
    public Dictionary<int, CreatureData> CreatureDic { get; private set; } = new Dictionary<int, CreatureData>();

    public void Init()
    {
        CreatureDic = LoadJson<CreatureDataLoader, int, CreatureData>("CreatureData").MakeDict();
    }

    private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>(path);
        return JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }


}
