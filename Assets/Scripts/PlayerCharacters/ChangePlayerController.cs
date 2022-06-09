using UnityEngine;

public class ChangePlayerController
{
    private CharacterView[] _characterViews;
    private int _currentControllerNumber = 0;
    private PlayerPhysicsController _player;
    private CharacterView _currentCharacter;

    public CharacterView CurrentCharacter => _currentCharacter;

    public ChangePlayerController(CharacterView[] characterViews, PlayerPhysicsController player)
    {
        _characterViews = characterViews;
        _currentCharacter = characterViews[_currentControllerNumber];
        _player = player;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
}
