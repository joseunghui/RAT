using UnityEngine;

public class InitBase : MonoBehaviour
{
    protected bool _init = false;

    public virtual bool Init()
    {
        // �ѹ��̶� �ʱ�ȭ ������ FALSE ���� : ���� ó��
        if (_init)
            return false;

        // �װ� �ƴ϶�� true ���� : ���� ó��
        _init = true;
        return true;
    }

    // Ȥ�ö� Init�� ȣ������ �ʾ����� Awake�� �־ ȣ�����ֱ�
    private void Awake()
    {
        Init();
    }
}
