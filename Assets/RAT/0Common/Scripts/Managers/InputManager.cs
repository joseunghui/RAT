using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.KeyEvent> KeyAction = null;
    public Action MouseAction = null;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (Input.anyKey && KeyAction != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
                KeyAction.Invoke(Define.KeyEvent.Up);
            else if (Input.GetKeyDown(KeyCode.S))
                KeyAction.Invoke(Define.KeyEvent.Down);
            else if (Input.GetKeyDown(KeyCode.D))
                KeyAction.Invoke(Define.KeyEvent.Right);
            else if (Input.GetKeyDown(KeyCode.A))
                KeyAction.Invoke(Define.KeyEvent.Left);
        }
            

        if (MouseAction != null)
            MouseAction.Invoke();
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
