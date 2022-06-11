internal sealed class InputInitialize : IStart
{
    private IUserInput _inputHorizontal;
    private IUserInput _inputVertical;
    private IUserInputKey _inputKeySpace;

    public InputInitialize()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _inputKeySpace = new InputKeySpace();
    }

    public (IUserInput horizontal, IUserInput vertical) GetInputAxis()
    {
        return (_inputHorizontal, _inputVertical);
    }

    public IUserInputKey GetInputSpaceKey()
    {
        return _inputKeySpace;
    }

    public void Start()
    {
    }
}
