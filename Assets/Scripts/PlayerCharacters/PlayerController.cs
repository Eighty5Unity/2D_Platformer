using UnityEngine;

public class PlayerController : IUpdate, IFixedUpdate, IOnDestroy
{
    private ChangePlayerController _playerController;
    private CharacterView _currentCharacter;
    private float _horizontal;
    private IUserInput _horizontalInput;
    private bool _pressUpKey;
    private bool _doJump;
    private IUserInputKey _upKey;

    public PlayerController(ChangePlayerController playerController, (IUserInput horizontal, IUserInput vertical) input, IUserInputKey upKey)
    {
        _playerController = playerController;
        _horizontalInput = input.horizontal;
        _upKey = upKey;
        _horizontalInput.AxisOnChange += HorizontalAxisOnChange;
        _upKey.PressKey += PressUpKey;
    }

    private void HorizontalAxisOnChange(float value)
    {
        _horizontal = value;
    }

    private void PressUpKey(bool value)
    {
        _pressUpKey = value;
    }

    public void Update(float deltaTime)
    {
        if (_pressUpKey)
        {
            _doJump = true;
        }
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        _currentCharacter = _playerController.CurrentCharacter;

        var newVelocity = 0f;
        if (_horizontal != 0)
        {
            newVelocity = fixedDeltaTime * _currentCharacter.WalkSpeed * (_horizontal < 0 ? -1 : 1);
            _currentCharacter.SpriteRenderer.flipX = _horizontal < 0;
        }

        _currentCharacter.Rigidbody.velocity = _currentCharacter.Rigidbody.velocity.Change(x: newVelocity);

        if (_currentCharacter.IsGround && _doJump && Mathf.Abs(_currentCharacter.Rigidbody.velocity.y) <= _currentCharacter.FlyThresh)
        {
            _doJump = false;
            _currentCharacter.IsGround = false;
            _currentCharacter.Rigidbody.AddForce(Vector3.up * _currentCharacter.JumpStartSpeed);
        }

        if (_currentCharacter.IsGround)
        {
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, _horizontal != 0 ? CharacterAnimationTracks.walk : CharacterAnimationTracks.idle, true,
                _currentCharacter.AnimationSpeed);
        }
        else if (Mathf.Abs(_currentCharacter.Rigidbody.velocity.y) > _currentCharacter.FlyThresh)
        {
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, CharacterAnimationTracks.jump, true,
                _currentCharacter.AnimationSpeed);
        }
    }

    public void OnDestroy()
    {
        _horizontalInput.AxisOnChange -= HorizontalAxisOnChange;
        _upKey.PressKey -= PressUpKey;
    }
}
