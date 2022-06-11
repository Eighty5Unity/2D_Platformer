public class ChangePlayerController : IUpdate, IOnDestroy
{
    private CharacterView[] _characterViews;
    private int _currentControllerNumber = 0;
    private PlayerController _player;
    private CharacterView _currentCharacter;
    public CharacterView CurrentCharacter => _currentCharacter;
    private bool _isSpaceKeyPress;
    private IUserInputKey _spaceKey;

    public ChangePlayerController(CharacterView[] characterViews, PlayerController player, IUserInputKey spaceKey)
    {
        _characterViews = characterViews;
        _currentCharacter = characterViews[_currentControllerNumber];
        _player = player;
        _spaceKey = spaceKey;
        _spaceKey.PressKey += PressSpaceKey;
    }

    private void PressSpaceKey(bool value)
    {
        _isSpaceKeyPress = value;
    }

    public void Update(float deltaTime)
    {
        if (_isSpaceKeyPress)
        {
            _currentControllerNumber++;
            if(_currentControllerNumber >= _characterViews.Length)
            {
                _currentControllerNumber = 0;
            }
            _currentCharacter = _characterViews[_currentControllerNumber];
            _player.CharacterView = _currentCharacter;
        }
    }

    public void OnDestroy()
    {
        _spaceKey.PressKey -= PressSpaceKey;
    }
}
