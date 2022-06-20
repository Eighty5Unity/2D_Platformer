internal sealed class InputInitialize : IStart
{
    private IUserInput _inputHorizontal;
    private IUserInput _inputVertical;
    private IUserInputKey _inputKeySpace;
    private IUserInputKey _inputKeyUpArrow;
    private IUserInputKey _inputKeyE;
    private IUserInputKey _inputKeyQ;

    public InputInitialize()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _inputKeySpace = new InputKeySpace();
        _inputKeyUpArrow = new InputKeyUp();
        _inputKeyE = new InputKeyE();
        _inputKeyQ = new InputKeyQ();
    }

    public (IUserInput horizontal, IUserInput vertical) GetInputAxis()
    {
        return (_inputHorizontal, _inputVertical);
    }

    public IUserInputKey GetInputSpaceKey()
    {
        return _inputKeySpace;
    }

    public IUserInputKey GetInputUpKey()
    {
        return _inputKeyUpArrow;
    }

    public IUserInputKey GetInputEKey()
    {
        return _inputKeyE;
    }

    public IUserInputKey GetInputQKey()
    {
        return _inputKeyQ;
    }

    public void Start()
    {
    }
}
