using Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;


// 아이템을 구분할 수 있는 Key 값을 Generic으로 만들어주기 (찾기 편하도록)
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
