using System;
using UnityEngine;

public class InputKeySpace : IUserInputKey
{
    public event Action<bool> PressKey = delegate (bool b) { };

    public void GetPressKey()
    {
        PressKey.Invoke(Input.GetKeyDown(KeyCode.Space));
    }
}
