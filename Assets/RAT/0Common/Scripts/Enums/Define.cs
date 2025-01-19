using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum CameraMode
    {
        Default,
        Chapter,
        Map,
    }
    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum KeyEvent
    {
        Up,
        Down,
        Left,
        Right,
    }

    public enum MouseEvent
    {
        Press,
        DubbleClick,
        Click,
    }
}
