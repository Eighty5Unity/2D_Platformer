using UnityEngine;

public class PlayerPhysicsController
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private CharacterView _characterView;
    public CharacterView CharacterView { get => _characterView; set => _characterView = value; }
    private SpriteAnimation _spriteAnimator;
    private ContactsPoller _contactsPoller;

    public PlayerPhysicsController(CharacterView characterView, SpriteAnimation spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;

        _contactsPoller = new ContactsPoller(characterView.Collider);
    }

    public void FixedUpdate()
    {
        var doJump = Input.GetKeyDown(KeyCode.W);//make in Update
        var xAxisInput = Input.GetAxis(Horizontal);

        _contactsPoller.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > 0;

        if (isGoSideWay)
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;

        var newVelocity = 0f;

        if (isGoSideWay &&
            (xAxisInput > 0 || !_contactsPoller.HasLeftContacts) &&
            (xAxisInput < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
        }

        _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocity);

        if (_contactsPoller.IsGrounded && doJump && Mathf.Abs(_characterView.Rigidbody.velocity.y) <= _characterView.FlyThresh)
        {
            _characterView.Rigidbody.AddForce(Vector3.up * _characterView.JumpStartSpeed);
        }

        if (_contactsPoller.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? CharacterAnimationTracks.walk : CharacterAnimationTracks.idle, true,
                _characterView.AnimationSpeed);
        }
        else if (Mathf.Abs(_characterView.Rigidbody.velocity.y) > _characterView.FlyThresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, CharacterAnimationTracks.jump, true,
                _characterView.AnimationSpeed);
        }
    }
}
