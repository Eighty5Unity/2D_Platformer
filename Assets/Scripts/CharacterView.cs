using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;

    [Header("Settings")]
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _jumpStartSpeed = 2f;
    [SerializeField] private float _movingThresh = 0.1f;
    [SerializeField] private float _flyThresh = 0.4f;
    [SerializeField] private float _groundLevel = 0.2f;
    [SerializeField] private float _acceleration = -9.8f;

    [Header("AnimationSettings")]
    [SerializeField] private float _animationSpeed = 3f;
    [SerializeField] private bool _loop;


    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public SpriteAnimationConfig SpriteAnimationConfig => _spriteAnimationConfig;
    public float WalkSpeed => _walkSpeed;
    public float AnimationSpeed => _animationSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MovingThresh => _movingThresh;
    public float FlyThresh => _flyThresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
    public bool AnimationLoop => _loop;

}
