using UnityEngine;

public class PlayerController : IFixedUpdate, IOnDestroy
{
    private ChangePlayerController _playerController;
    private CharacterView _currentCharacter;
    private float _horizontal;
    private IUserInput _horizontalInput;
    private bool _doJump;
    private IUserInputKey _upKey;
    private IUserInputKey _eKey;
    private CharacterView _hatmanInWell;

    public PlayerController(ChangePlayerController playerController, (IUserInput horizontal, IUserInput vertical) input, IUserInputKey upKey, IUserInputKey eKey)
    {
        _playerController = playerController;
        _horizontalInput = input.horizontal;
        _upKey = upKey;
        _eKey = eKey;
        _horizontalInput.AxisOnChange += HorizontalAxisOnChange;
        _upKey.PressKey += PressUpKey;
        _eKey.PressKey += PressEKey;
    }

    private void HorizontalAxisOnChange(float value)
    {
        _horizontal = value;
    }

    private void PressUpKey(bool value)
    {
        if (value)
        {
            _doJump = true;
        }
    }

    private void PressEKey(bool value)
    {
        if (value)
        {
            if (_playerController.CurrentCharacter.IsCanEnterHouse || _playerController.CurrentCharacter.IsAtHouse)
            {
                EnterExitHouse();
            }
            else if (_playerController.CurrentCharacter.IsCanUseWell)
            {
                UseWell();
            }
        }
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        _currentCharacter = _playerController.CurrentCharacter;

        if(_horizontal == 0) //Idle
        {
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, CharacterAnimationTracks.idle, _currentCharacter.AnimationIdleLoop, _currentCharacter.AnimationIdleSpeed);
        }
        else if (_horizontal != 0 && !_currentCharacter.IsAtHouse) //Walk
        {
            var newVelocity = fixedDeltaTime * _currentCharacter.WalkSpeed * (_horizontal < 0 ? -1 : 1);
            _currentCharacter.SpriteRenderer.flipX = _horizontal < 0;
            _currentCharacter.Rigidbody.velocity = _currentCharacter.Rigidbody.velocity.Change(x: newVelocity);
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, CharacterAnimationTracks.walk, _currentCharacter.AnimationWalkLoop, _currentCharacter.AnimationWalkSpeed);
        }

        if (_currentCharacter.IsGround && _doJump) //Jump
        {
            _doJump = false;
            _currentCharacter.Rigidbody.AddForce(Vector3.up * _currentCharacter.JumpStartSpeed);
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, CharacterAnimationTracks.jump, _currentCharacter.AnimationJumpLoop, _currentCharacter.AnimationJumpSpeed);
        }
    }

    public void OnDestroy()
    {
        _horizontalInput.AxisOnChange -= HorizontalAxisOnChange;
        _upKey.PressKey -= PressUpKey;
        _eKey.PressKey -= PressEKey;
    }

    private void EnterExitHouse()
    {
        _currentCharacter = _playerController.CurrentCharacter;

        if (_currentCharacter.IsAtHouse)
        {
            _currentCharacter.IsAtHouse = false;
            _currentCharacter.gameObject.SetActive(true);
        }

        else if (_currentCharacter.IsCanEnterHouse)
        {
            _currentCharacter.IsAtHouse = true;
            _currentCharacter.gameObject.SetActive(false);
        }
    }

    private void UseWell()
    {
        if(_playerController.CurrentCharacter.CharacterEnum == CharactersEnum.Hatman)
        {
            _hatmanInWell = _playerController.CurrentCharacter;
            _hatmanInWell.gameObject.SetActive(false);
        }
        else if(_playerController.CurrentCharacter.CharacterEnum == CharactersEnum.Bearded && _hatmanInWell != null)
        {
            _hatmanInWell.gameObject.SetActive(true);
            _hatmanInWell = null;
        }
    }
}
