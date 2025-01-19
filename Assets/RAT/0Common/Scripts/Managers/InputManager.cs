using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.KeyEvent> KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;


    bool _mousePressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (KeyAction != null)
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
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _mousePressed = true;
            }
            else
            {
                if (_mousePressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _mousePressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
