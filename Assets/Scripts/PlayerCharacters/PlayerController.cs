using UnityEngine;

public class PlayerController : IUpdate, IOnDestroy
{
    private ChangePlayerController _playerController;
    public CharacterView CharacterView => _playerController.CurrentCharacter;
    private SpriteAnimation _spriteAnimation;
    private float _horizontal;
    private float _vertical;
    private IUserInput _horizontalInput;
    private IUserInput _verticalInput;
    private float _yVelocity;

    public PlayerController(ChangePlayerController playerController, (IUserInput horizontal, IUserInput vertical) input)
    {
        _playerController = playerController;
        _spriteAnimation = playerController.CurrentCharacter.SpriteAnimation;
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
        var doJump = _vertical > 0;

        var isGoSideWay = Mathf.Abs(_horizontal) > _playerController.CurrentCharacter.MovingThresh;
        if (isGoSideWay)
        {
            GoSideWay(_horizontal, deltaTime);
        }

        if (IsGrounded())
        {
            _playerController.CurrentCharacter.SpriteAnimation.StartAnimation(_playerController.CurrentCharacter.SpriteRenderer, isGoSideWay ? CharacterAnimationTracks.walk : CharacterAnimationTracks.idle, true, _playerController.CurrentCharacter.AnimationSpeed);

            if (doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _playerController.CurrentCharacter.JumpStartSpeed;
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
        _playerController.CurrentCharacter.transform.position += Vector3.right * deltaTime * _playerController.CurrentCharacter.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
        _playerController.CurrentCharacter.SpriteRenderer.flipX = xAxisInput < 0;
    }

    private bool IsGrounded()
    {
        return _playerController.CurrentCharacter.transform.position.y <= _playerController.CurrentCharacter.GroundLevel && _yVelocity <= 0;
    }

    private void MovementCharacter()
    {
        _playerController.CurrentCharacter.transform.position.Change(y: _playerController.CurrentCharacter.GroundLevel);
    }

    private void LandingCharacter(float deltaTime)
    {
        _yVelocity += _playerController.CurrentCharacter.Acceleration * deltaTime;
        if(Mathf.Abs(_yVelocity) > _playerController.CurrentCharacter.FlyThresh)
        {
            _spriteAnimation.StartAnimation(_playerController.CurrentCharacter.SpriteRenderer, CharacterAnimationTracks.jump, true, _playerController.CurrentCharacter.AnimationSpeed);
        }

        _playerController.CurrentCharacter.transform.position += Vector3.up * deltaTime * _yVelocity;
    }

    public void OnDestroy()
    {
        _horizontalInput.AxisOnChange -= HorizontalAxisOnChange;
        _verticalInput.AxisOnChange -= VerticalAxisOnChange;
    }
}
