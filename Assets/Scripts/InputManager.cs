using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action clickAction;
    public void Click()
    {
        clickAction?.Invoke();
    }
}
