using System;
using UnityEngine;

public class InputKeyUp : IUserInputKey
{
    public event Action<bool> PressKey = delegate(bool b) { };

    public void GetPressKey()
    {
        PressKey.Invoke(Input.GetKeyDown(KeyCode.W));
    }
}
