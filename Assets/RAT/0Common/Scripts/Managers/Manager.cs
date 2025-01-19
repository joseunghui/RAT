using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager s_instance;
    static Manager Instance { get { Init(); return s_instance; } }

    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    //PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SoundManager _sound = new SoundManager();
    SceneLoadManager _scene = new SceneLoadManager();
    UIManager _ui = new UIManager();

    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    //public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static SceneLoadManager Scene { get { return Instance._scene; } }
    public static UIManager UI { get { return Instance._ui; } }

    private void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("Manager");
            if (go == null)
            {
                go = new GameObject { name = "Manager" };
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Manager>();

            // data
            s_instance._data.init();

            //sound
            s_instance._sound.init();


            // Pool
            // s_instance._pool.init();
        }
    }

    // 씬 이동 시 없애줘야 하는 것들을 한방에 없애기 
    // 호출은 SceneManagerEx.cs 에서
    public static void Clear()
    {
        // Data는 클리어 하지 않음
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.Clear();
        // Pool.Clear();
    }
}
