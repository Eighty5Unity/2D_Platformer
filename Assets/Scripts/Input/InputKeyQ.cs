using System;
using UnityEngine;

public class InputKeyQ : IUserInputKey
{
    public event Action<bool> PressKey = delegate(bool b) { };

    public void GetPressKey()
    {
        PressKey.Invoke(Input.GetKey(KeyCode.Q));
    }
}
