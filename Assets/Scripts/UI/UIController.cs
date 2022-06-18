public class UIController : IUpdate, IOnDestroy
{
    private UIView _uiView;
    private ChangePlayerController _changePlayerController;
    private int _currentPlayerIndex;
    private IUserInputKey _spaceKey;

    public UIController(UIView uiView, ChangePlayerController changePlayerController, IUserInputKey spaceKey)
    {
        _uiView = uiView;
        _changePlayerController = changePlayerController;
        _currentPlayerIndex = changePlayerController.CurrentControllerNumber;
        _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
        _spaceKey = spaceKey;
        _spaceKey.PressKey += ChangeCharacterAvatar;
    }

    public void Update(float deltaTime)
    {
        //Set hint text
        if (_changePlayerController.CurrentCharacter.IsCanEnterHouse)
        {
            _uiView.HintText.text = StringHints.KeyE + " " + StringHints.EnterHouse;
        }
        else if (_changePlayerController.CurrentCharacter.IsAtHouse)
        {
            _uiView.HintText.text = StringHints.KeyE + " " + StringHints.ExitHouse;
        }
        else
        {
            _uiView.HintText.text = StringHints.CharacterTask(_changePlayerController.CurrentCharacter.CharacterEnum); // make this hint if pressKey Q
        }
    }

    public void OnDestroy()
    {
        _spaceKey.PressKey -= ChangeCharacterAvatar;
    }

    private void ChangeCharacterAvatar(bool value)
    {
        if (_currentPlayerIndex != _changePlayerController.CurrentControllerNumber)
        {
            _currentPlayerIndex = _changePlayerController.CurrentControllerNumber;
            _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
        }
    }
}
