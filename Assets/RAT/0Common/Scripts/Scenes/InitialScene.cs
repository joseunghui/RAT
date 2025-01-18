using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScene : BasicScene
{
    [SerializeField]
    GameObject SafeArea;

    private void Start()
    {
        Init();

        Manager.UI.MakeSubItem<GameStartPanel>(parent: SafeArea.transform);
    }

    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.Initial;
    }

    public override void Clear()
    {
        Debug.Log($"{SceneType} Scene Clear!");
    }

}
