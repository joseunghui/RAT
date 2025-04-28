using UnityEngine;
using UnityEngine.EventSystems;

public class UI_TitleScene : UI_Scene
{
    #region Enum
    enum GameObjects
    {
        StartImage,

    }

    enum Texts
    {
        StartMessage,

    }
    #endregion

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        // Bind
        BindObjects(typeof(GameObjects));
        BindTexts(typeof(Texts));

        // Use
        GetObject((int)GameObjects.StartImage).BindEvent( (evt) =>
        {
            Debug.Log("Start Game!");

            Managers.Scene.LoadScene(Define.EScene.Chapter1Scene);
        });

        // Addressable
        // ó������ Addressable�� ������ �ε��� ���� �ؾ��ϴϱ� ��Ȱ��ȭ + ���� ���ֱ�
        GetObject((int)GameObjects.StartImage).gameObject.SetActive(false);
        GetText((int)Texts.StartMessage).text = "Loading..";

        // Data Loading
        StartLoadAssets();

        return true;
    }

    void StartLoadAssets()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                // DataSheet �ε�
                //Managers.Data.Init();

                // ������ �ε� + Addressable �ε��� �������� GameScene���� �̵��� �� �ְ� Ȱ��ȭ + ���� ����
                GetObject((int)GameObjects.StartImage).gameObject.SetActive(true);
                GetText((int)Texts.StartMessage).text = $"Touch to Start!";
            }
        });
    }
}
