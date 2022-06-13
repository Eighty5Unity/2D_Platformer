using UnityEngine;

public class PlayerController : IUpdate, IOnDestroy
{
    private ChangePlayerController _playerController;
    private CharacterView _currentCharacter;
    private float _horizontal;
    private float _vertical;
    private IUserInput _horizontalInput;
    private IUserInput _verticalInput;
    private float _yVelocity;

    public PlayerController(ChangePlayerController playerController, (IUserInput horizontal, IUserInput vertical) input)
    {
        _playerController = playerController;
        _horizontalInput = input.horizontal;
        _verticalInput = input.vertical;
        _horizontalInput.AxisOnChange += HorizontalAxisOnChange;
        _verticalInput.AxisOnChange += VerticalAxisOnChange;
    }

    private void HorizontalAxisOnChange(float value)
    {
        _horizontal = value;
    }

    private void VerticalAxisOnChange(float value)
    {
        _vertical = value;
    }

    public void Update(float deltaTime)
    {
        _currentCharacter = _playerController.CurrentCharacter;

        var doJump = _vertical > 0;

        var isGoSideWay = Mathf.Abs(_horizontal) > _currentCharacter.MovingThresh;
        if (isGoSideWay)
        {
            GoSideWay(_horizontal, deltaTime);
        }

        if (IsGrounded())
        {
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, isGoSideWay ? CharacterAnimationTracks.walk : CharacterAnimationTracks.idle, true, _currentCharacter.AnimationSpeed);

            if (doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _currentCharacter.JumpStartSpeed;
            }
            else if(_yVelocity < 0)
            {
                _yVelocity = 0;
                MovementCharacter();
            }
        }
        else
        {
            LandingCharacter(deltaTime);
        }
    }

    private void GoSideWay(float xAxisInput, float deltaTime)
    {
        _currentCharacter.transform.position += Vector3.right * deltaTime * _currentCharacter.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
        _currentCharacter.SpriteRenderer.flipX = xAxisInput < 0;
    }

    private bool IsGrounded()
    {
        return _currentCharacter.transform.position.y <= _currentCharacter.GroundLevel && _yVelocity <= 0;
    }

    private void MovementCharacter()
    {
        _currentCharacter.transform.position.Change(y: _currentCharacter.GroundLevel);
    }

    private void LandingCharacter(float deltaTime)
    {
        _yVelocity += _currentCharacter.Acceleration * deltaTime;
        if(Mathf.Abs(_yVelocity) > _currentCharacter.FlyThresh)
        {
            _currentCharacter.SpriteAnimation.StartAnimation(_currentCharacter.SpriteRenderer, CharacterAnimationTracks.jump, true, _currentCharacter.AnimationSpeed);
        }

        _currentCharacter.transform.position += Vector3.up * deltaTime * _yVelocity;
    }

    public void OnDestroy()
    {
        _horizontalInput.AxisOnChange -= HorizontalAxisOnChange;
        _verticalInput.AxisOnChange -= VerticalAxisOnChange;
    }
}
