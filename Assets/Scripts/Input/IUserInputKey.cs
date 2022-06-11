using System;

public interface IUserInputKey
{
    event Action<bool> PressKey;

    void GetPressKey();
}
