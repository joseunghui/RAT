using UnityEngine;
using UnityEngine.UI;

public class GameStartPanel : UI_Base
{
    enum Buttons
    {
        StartBtn,
        EndBtn,
    }


    [SerializeField]
    Button StartBtn;

    [SerializeField]
    Button EndBtn;


    private void Start()
    {
        init();
    }

    public override void init()
    {
        Bind<Button>(typeof(Buttons));

        StartBtn.gameObject.BindEvent((PointerEventData) => { onClickStartBtn(); });
        EndBtn.gameObject.BindEvent((PointerEventData) => { onClickEndBtn(); });
    }


    void onClickStartBtn()
    {
        Debug.Log("StartBtn 클릭");

        StartBtn.GetComponent<Animator>().SetTrigger("start");
    }

    void onClickEndBtn()
    {
        Debug.Log("EndBtn 클릭");

        EndBtn.GetComponent<Animator>().SetTrigger("start");
    }
}
