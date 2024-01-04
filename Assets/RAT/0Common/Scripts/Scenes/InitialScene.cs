using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScene : BasicScene
{
    private void Start()
    {
        Init();
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
