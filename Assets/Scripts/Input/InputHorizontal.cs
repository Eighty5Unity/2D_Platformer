using System;
using UnityEngine;

public sealed class InputHorizontal : IUserInput
{
    public event Action<float> AxisOnChange = delegate(float f) { };

    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(AxisAndKeyManager.HORIZONTAL));
    }
}
