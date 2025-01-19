using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScene : BasicScene
{
    [SerializeField]
    GameObject CanvasArea;

    private void Start()
    {
        Init();

        Manager.UI.MakeSubItem<GameStartPanel>(parent: CanvasArea.transform);
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
