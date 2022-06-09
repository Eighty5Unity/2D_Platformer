using UnityEngine;

public class PlayerController
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private CharacterView _characterView;
    public CharacterView CharacterView { get => _characterView; set => _characterView = value; }
    private SpriteAnimation _spriteAnimation;
    private float _yVelocity;

    public PlayerController(CharacterView characterView, SpriteAnimation spriteAnimation)
    {
        _characterView = characterView;
        _spriteAnimation = spriteAnimation;
    }

    public void Update()
    {
        var doJump = Input.GetAxis(Vertical) > 0; //
        var xAxisInput = Input.GetAxis(Horizontal); // make in InputSystem

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingThresh;
        if (isGoSideWay)
        {
            GoSideWay(xAxisInput);
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
            LandingCharacter();
        }
    }

    private void GoSideWay(float xAxisInput)
    {
        _characterView.transform.position += Vector3.right * Time.deltaTime * _characterView.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
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

    private void LandingCharacter()
    {
        _yVelocity += _characterView.Acceleration * Time.deltaTime;
        if(Mathf.Abs(_yVelocity) > _characterView.FlyThresh)
        {
            _spriteAnimation.StartAnimation(_characterView.SpriteRenderer, CharacterAnimationTracks.jump, true, _characterView.AnimationSpeed);
        }

        _characterView.transform.position += Vector3.up * Time.deltaTime * _yVelocity;
    }
}
