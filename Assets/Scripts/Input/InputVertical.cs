using System;
using UnityEngine;

public class InputVertical : IUserInput
{
    public event Action<float> AxisOnChange = delegate(float f) { };

    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(AxisAndKeyManager.VERTICAL));
    }
}
