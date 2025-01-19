using TMPro.EditorUtilities;
using UnityEngine;
using static Define;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int _level = 1;

    [SerializeField]
    float _speed = 10f;

    // Player Info
    float _hp = 1.0f;
    float _attack = 1.0f;
    Vector3 _destPos;

    public enum PlayerState // ���ÿ� �ΰ��� ���¸� ������ ����
    {
        Die,
        Attack,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle; // ���� ���� : Idle

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Manager.Input.KeyAction -= OnKeyDown;
        Manager.Input.MouseAction -= OnMouseClicked;

        Manager.Input.KeyAction += OnKeyDown;
        Manager.Input.MouseAction += OnMouseClicked;

        // hp & attack ����
        _hp = Manager.Data.StatDict[_level].hp;
        _attack = Manager.Data.StatDict[_level].attack;

        // play die animation
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("hp", _hp);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    void UpdateDie()
    {
        // play die animation
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("hp", 0);
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;

        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
        }

        // �ִϸ��̼�
        Animator animator = GetComponent<Animator>();
        // ���� ���� ���¿� ���� ������ �Ѱ��ش�
        animator.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {
        // Ű�� �����̸� Moving
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0); // ���� ����(speed == 0) : Idle ����
    }

    void OnKeyDown(Define.KeyEvent keyEvt)
    {
        Debug.Log($"OnKeyDown >> {keyEvt}");

        if (_state == PlayerState.Die)
            return;


        if (keyEvt == KeyEvent.Right)
        {
            // Filp
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

            float x_value = transform.position.x + (_speed * Time.deltaTime);
            
            _destPos = transform.position;
            _destPos.x = x_value;
        }
        else if (keyEvt == KeyEvent.Left)
        {
            // Filp
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            float x_value = transform.position.x - (_speed * Time.deltaTime);
            _destPos = transform.position;
            _destPos.x = x_value;
        }

        _state = PlayerState.Moving;

    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Debug.Log($"OnMouseClicked >> {evt}");

        if (_state == PlayerState.Die)
            return;

        // Click �ϸ� Attack
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("attack");

        
    }
}
