public class UIController : IUpdate
{
    private UIView _uiView;
    private ChangePlayerController _changePlayerController;
    private int _currentPlayerIndex;

    public UIController(UIView uiView, ChangePlayerController changePlayerController)
    {
        _uiView = uiView;
        _changePlayerController = changePlayerController;
        _currentPlayerIndex = changePlayerController.CurrentControllerNumber;
        _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
    }

    public void Update(float deltaTime)
    {
        if(_currentPlayerIndex != _changePlayerController.CurrentControllerNumber)
        {
            _currentPlayerIndex = _changePlayerController.CurrentControllerNumber;
            _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
        }
    }
}
