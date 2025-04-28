using UnityEngine;

public class InitBase : MonoBehaviour
{
    protected bool _init = false;

    public virtual bool Init()
    {
        // 한번이라도 초기화 했으면 FALSE 리턴 : 실패 처리
        if (_init)
            return false;

        // 그게 아니라면 true 리턴 : 성공 처리
        _init = true;
        return true;
    }

    // 혹시라도 Init을 호출하지 않았으면 Awake에 넣어서 호출해주기
    private void Awake()
    {
        Init();
    }
}
