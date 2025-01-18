using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("check");
    }

    void OnClickExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }


    void OnSceneMoveAfterExit(SceneType type)
    {
        Debug.Log($"OnSceneMoveAfterExit >> {type}");
        Manager.Scene.LoadScene(type);
    }
}
