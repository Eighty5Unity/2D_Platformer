using UnityEngine;

public class PlayerController : IUpdate, IOnDestroy
{
    private CharacterView _characterView;
    public CharacterView CharacterView { get => _characterView; set => _characterView = value; }
    private SpriteAnimation _spriteAnimation;
    private float _horizontal;
    private float _vertical;
    private IUserInput _horizontalInput;
    private IUserInput _verticalInput;
    private float _yVelocity;

    public PlayerController(CharacterView characterView, (IUserInput horizontal, IUserInput vertical) input)
    {
        _characterView = characterView;
        _spriteAnimation = characterView.SpriteAnimation;
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

        var isGoSideWay = Mathf.Abs(_horizontal) > _characterView.MovingThresh;
        if (isGoSideWay)
        {
            GoSideWay(_horizontal, deltaTime);
        }

        if (IsGrounded())
        {
            _spriteAnimation.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? CharacterAnimationTracks.walk : CharacterAnimationTracks.idle, true, _characterView.AnimationSpeed);

            if (doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _characterView.JumpStartSpeed;
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
        _characterView.transform.position += Vector3.right * deltaTime * _characterView.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
        _characterView.SpriteRenderer.flipX = xAxisInput < 0;
    }

    private bool IsGrounded()
    {
        return _characterView.transform.position.y <= _characterView.GroundLevel && _yVelocity <= 0;
    }

    private void MovementCharacter()
    {
        _characterView.transform.position.Change(y: _characterView.GroundLevel);
    }

    private void LandingCharacter(float deltaTime)
    {
        _yVelocity += _characterView.Acceleration * deltaTime;
        if(Mathf.Abs(_yVelocity) > _characterView.FlyThresh)
        {
            _spriteAnimation.StartAnimation(_characterView.SpriteRenderer, CharacterAnimationTracks.jump, true, _characterView.AnimationSpeed);
        }

        _characterView.transform.position += Vector3.up * deltaTime * _yVelocity;
    }

    public void OnDestroy()
    {
        _horizontalInput.AxisOnChange -= HorizontalAxisOnChange;
        _verticalInput.AxisOnChange -= VerticalAxisOnChange;
    }
}
