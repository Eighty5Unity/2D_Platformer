public sealed class InputController : IUpdate
{
    private readonly IUserInput _horizontalAxis;
    private readonly IUserInput _verticalAxis;

    public InputController((IUserInput horizontal, IUserInput vertical) input)
    {
        _horizontalAxis = input.horizontal;
        _verticalAxis = input.vertical;
    }

    public void Update(float deltaTime)
    {
        _horizontalAxis.GetAxis();
        _verticalAxis.GetAxis();
    }
}
