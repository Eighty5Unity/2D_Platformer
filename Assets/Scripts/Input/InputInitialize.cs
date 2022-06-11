internal sealed class InputInitialize : IStart
{
    private IUserInput _inputHorizontal;
    private IUserInput _inputVertical;

    public InputInitialize()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
    }

    public (IUserInput horizontal, IUserInput vertical) GetInputAxis()
    {
        return (_inputHorizontal, _inputVertical);
    }

    public void Start()
    {
    }
}
