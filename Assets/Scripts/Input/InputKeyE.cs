using System;
using UnityEngine;

public class InputKeyE : IUserInputKey
{
    public event Action<bool> PressKey = delegate (bool b) { };

    public void GetPressKey()
    {
        PressKey.Invoke(Input.GetKeyDown(KeyCode.E));
    }
}
