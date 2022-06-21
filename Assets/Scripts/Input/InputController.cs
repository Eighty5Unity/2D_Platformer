public sealed class InputController : IUpdate
{
    private readonly IUserInput _horizontalAxis;
    private readonly IUserInput _verticalAxis;
    private readonly IUserInputKey _spaceKey;
    private readonly IUserInputKey _upKey;
    private readonly IUserInputKey _eKey;
    private readonly IUserInputKey _qKey;

    public InputController(InputInitialize input)
    {
        _horizontalAxis = input.GetInputAxis().horizontal;
        _verticalAxis = input.GetInputAxis().vertical;
        _spaceKey = input.GetInputSpaceKey();
        _upKey = input.GetInputUpKey();
        _eKey = input.GetInputEKey();
        _qKey = input.GetInputQKey();
    }

    public void Update(float deltaTime)
    {
        _horizontalAxis.GetAxis();
        _verticalAxis.GetAxis();
        _spaceKey.GetPressKey();
        _upKey.GetPressKey();
        _eKey.GetPressKey();
        _qKey.GetPressKey();
    }
}
