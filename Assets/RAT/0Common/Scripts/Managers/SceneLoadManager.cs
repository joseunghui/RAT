using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager
{
    public BasicScene CurrentScene { get { return GameObject.FindAnyObjectByType<BasicScene>(); } }

    public void LoadScene(SceneType type)
    {
        // 다른 씬 로드 시 불필요한 메모리 한방에 날려주기
        Manager.Clear();

        SceneManager.LoadScene(GetSceneName(type));
    }

    // Enum속 씬 타입을 string으로 가져오기
    string GetSceneName(SceneType type)
    {
        return System.Enum.GetName(typeof(SceneType), type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
