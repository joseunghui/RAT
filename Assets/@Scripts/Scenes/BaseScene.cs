using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public abstract class BaseScene : InitBase
{
    public bool TestMode = true;

    public EScene SceneType { get; protected set; } = EScene.Unknown;


    public override bool Init()
    {
#if UNITY_EDITOR
        TestMode = true;
#else
		TestMode = false;
#endif
        if (base.Init() == false)
            return false;

        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));

        if (obj == null)
        {
            GameObject go = new GameObject() { name = "@EventSystem" };
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }

        return true;
    }

    public abstract void Clear();

}
