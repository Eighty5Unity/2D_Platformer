public sealed class InputController : IUpdate
{
    private readonly IUserInput _horizontalAxis;
    private readonly IUserInput _verticalAxis;
    private readonly IUserInputKey _spaceKey;

    public InputController((IUserInput horizontal, IUserInput vertical) input, IUserInputKey key)
    {
        _horizontalAxis = input.horizontal;
        _verticalAxis = input.vertical;
        _spaceKey = key;
    }

    public void Update(float deltaTime)
    {
        _horizontalAxis.GetAxis();
        _verticalAxis.GetAxis();
        _spaceKey.GetPressKey();
    }
}
