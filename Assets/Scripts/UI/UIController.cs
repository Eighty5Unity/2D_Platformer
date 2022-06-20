using UnityEngine;

public class UIController : IOnDestroy
{
    private UIView _uiView;
    private ChangePlayerController _changePlayerController;
    private int _currentPlayerIndex;
    private IUserInputKey _spaceKey;
    private IUserInputKey _qKey;

    public UIController(UIView uiView, ChangePlayerController changePlayerController, IUserInputKey spaceKey, IUserInputKey qKey)
    {
        _uiView = uiView;
        _changePlayerController = changePlayerController;
        _currentPlayerIndex = changePlayerController.CurrentControllerNumber;
        _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
        _spaceKey = spaceKey;
        _spaceKey.PressKey += ChangeCharacterAvatar;
        _qKey = qKey;
        _qKey.PressKey += ShowCharacterHint;
    }

    public void OnDestroy()
    {
        _spaceKey.PressKey -= ChangeCharacterAvatar;
        _qKey.PressKey -= ShowCharacterHint;
    }

    private void ChangeCharacterAvatar(bool value)
    {
        //if (!value)
        //{
        //    return;
        //}

        if (_currentPlayerIndex != _changePlayerController.CurrentControllerNumber)
        {
            _currentPlayerIndex = _changePlayerController.CurrentControllerNumber;
            _uiView.CurrentCharacterImage.sprite = _uiView.CharacterImages[_currentPlayerIndex];
        }
    }

    private void ShowCharacterHint(bool value)
    {
        if (value)
        {
            _uiView.HintText.text = StringHints.CharacterTask(_changePlayerController.CurrentCharacter.CharacterEnum);
            return;
        }

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
            _uiView.HintText.text = "";
        }
    }
}
