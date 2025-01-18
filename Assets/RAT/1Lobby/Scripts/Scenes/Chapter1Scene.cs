using UnityEngine;

public class Chapter1Scene : BasicScene
{
   
    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.Chapter1;
    }

    public override void Clear()
    {
        Debug.Log($"{SceneType} Scene Clear!");
    }

}
