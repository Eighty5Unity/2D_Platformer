using System;

public interface IUserInput
{
    event Action<float> AxisOnChange;

    void GetAxis();
}
