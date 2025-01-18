using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager
{
    public BasicScene CurrentScene { get { return GameObject.FindAnyObjectByType<BasicScene>(); } }

    public void LoadScene(SceneType type)
    {
        // �ٸ� �� �ε� �� ���ʿ��� �޸� �ѹ濡 �����ֱ�
        Manager.Clear();

        SceneManager.LoadScene(GetSceneName(type));
    }

    // Enum�� �� Ÿ���� string���� ��������
    string GetSceneName(SceneType type)
    {
        return System.Enum.GetName(typeof(SceneType), type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
