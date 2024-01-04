using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    static Manager s_instance;
    static Manager Instance { get { Init(); return s_instance; } }

    //InputManager _input = new InputManager();
    //PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    //SoundManager _sound = new SoundManager();
    //SceneManagerEx _scene = new SceneManagerEx();
    UIManager _ui = new UIManager();

    //public static InputManager Input { get { return Instance._input; } }
    //public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    //public static SoundManager Sound { get { return Instance._sound; } }
    //public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static UIManager UI { get { return Instance._ui; } }

    private void Start()
    {
        Init();
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

            // sound
            // s_instance._sound.init();

            // Pool
            // s_instance._pool.init();
        }
    }
}
