public sealed class InputController : IUpdate
{
    private readonly IUserInput _horizontalAxis;
    private readonly IUserInput _verticalAxis;
    private readonly IUserInputKey _spaceKey;
    private readonly IUserInputKey _upKey;
    private readonly IUserInputKey _eKey;

    public InputController((IUserInput horizontal, IUserInput vertical) input, IUserInputKey spaceKey, IUserInputKey upKey, IUserInputKey eKey)
    {
        _horizontalAxis = input.horizontal;
        _verticalAxis = input.vertical;
        _spaceKey = spaceKey;
        _upKey = upKey;
        _eKey = eKey;
    }

    public void Update(float deltaTime)
    {
        _horizontalAxis.GetAxis();
        _verticalAxis.GetAxis();
        _spaceKey.GetPressKey();
        _upKey.GetPressKey();
        _eKey.GetPressKey();
    }
}
