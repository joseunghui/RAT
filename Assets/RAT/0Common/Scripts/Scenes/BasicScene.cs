using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BasicScene : MonoBehaviour
{
    public SceneType SceneType { get; protected set; } = SceneType.Unknown;

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        // EventSystem ������ �����ϴ� ����
        Object obj = GameObject.FindAnyObjectByType(typeof(EventSystem));

        if (obj == null)
            Manager.Resource.Instantiate("UI/EventSystem").name = "EventSystem";
    }

    public abstract void Clear();
}
