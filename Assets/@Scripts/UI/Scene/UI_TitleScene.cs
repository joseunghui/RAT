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
        // 처음에는 Addressable로 데이터 로딩을 먼저 해야하니까 비활성화 + 문구 없애기
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
                // DataSheet 로딩
                //Managers.Data.Init();

                // 데이터 로딩 + Addressable 로딩이 끝났으면 GameScene으로 이동할 수 있게 활성화 + 문구 생성
                GetObject((int)GameObjects.StartImage).gameObject.SetActive(true);
                GetText((int)Texts.StartMessage).text = $"Touch to Start!";
            }
        });
    }
}
