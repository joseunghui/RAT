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

        });


        return true;
    }
}
