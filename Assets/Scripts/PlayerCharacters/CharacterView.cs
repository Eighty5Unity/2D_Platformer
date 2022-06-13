using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Settings")]
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _jumpStartSpeed = 2f;
    [SerializeField] private float _acceleration = -9.8f;

    [Header("AnimationSettings")]
    [SerializeField] private float _animationIdleSpeed = 3f;
    [SerializeField] private bool _idleLoop;
    [SerializeField] private float _animationWalkSpeed = 3f;
    [SerializeField] private bool _walkLoop;
    [SerializeField] private float _animationJumpSpeed = 3f;
    [SerializeField] private bool _jumpLoop;


    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public SpriteAnimationConfig SpriteAnimationConfig => _spriteAnimationConfig;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;
    public float WalkSpeed => _walkSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float Acceleration => _acceleration;
    public float AnimationIdleSpeed => _animationIdleSpeed;
    public bool AnimationIdleLoop => _idleLoop;
    public float AnimationWalkSpeed => _animationWalkSpeed;
    public bool AnimationWalkLoop => _walkLoop;
    public float AnimationJumpSpeed => _animationJumpSpeed;
    public bool AnimationJumpLoop => _jumpLoop;

    private SpriteAnimation _spriteAnimation;
    public SpriteAnimation SpriteAnimation => _spriteAnimation;
    private bool _isGround;
    public bool IsGround { get => _isGround; set => _isGround = value; }

    private void Awake()
    {
        _spriteAnimation = new SpriteAnimation(_spriteAnimationConfig);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<GroundView>(out GroundView ground))
        {
            _isGround = true;
        }
    }
}
