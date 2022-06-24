using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _trigger;

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

    private SpriteAnimation _spriteAnimation;
    private bool _isGround;
    private CharactersEnum _character;
    private bool _isCanEnterHouse;
    private bool _isAtHouse;
    private bool _isTaskDone;
    private bool _isCanUseWell;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public SpriteAnimationConfig SpriteAnimationConfig => _spriteAnimationConfig;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Trigger => _trigger;
    public float WalkSpeed => _walkSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float Acceleration => _acceleration;
    public float AnimationIdleSpeed => _animationIdleSpeed;
    public bool AnimationIdleLoop => _idleLoop;
    public float AnimationWalkSpeed => _animationWalkSpeed;
    public bool AnimationWalkLoop => _walkLoop;
    public float AnimationJumpSpeed => _animationJumpSpeed;
    public bool AnimationJumpLoop => _jumpLoop;
    public SpriteAnimation SpriteAnimation => _spriteAnimation;
    public bool IsGround { get => _isGround; set => _isGround = value; }
    public CharactersEnum CharacterEnum => _character;
    public bool IsCanEnterHouse { get => _isCanEnterHouse; set => _isCanEnterHouse = value; }
    public bool IsAtHouse { get => _isAtHouse; set => _isAtHouse = value; }
    public bool IsTaskDone { get => _isTaskDone; set => _isTaskDone = value; }
    public bool IsCanUseWell { get => _isCanUseWell; set => _isCanUseWell = value; }

    private bool _meetWoman;
    private bool _meetHatman;
    private bool _meetOldman;
    private bool _meetBearded;

    public bool MeetWoman => _meetWoman;
    public bool MeetHatman => _meetHatman;
    public bool MeetOldman => _meetOldman;
    public bool MeetBearded => _meetBearded;

    private void Awake()
    {
        _spriteAnimation = new SpriteAnimation(_spriteAnimationConfig);
        _character = GetComponent<ICharacters>().Character;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<ICharacters>(out ICharacters character))
        {
            if (character.Character == CharactersEnum.Woman)
            {
                _meetWoman = true;
            }
            else if (character.Character == CharactersEnum.Oldman)
            {
                _meetOldman = true;
            }
            else if (character.Character == CharactersEnum.Bearded)
            {
                _meetBearded = true;
            }
            else if (character.Character == CharactersEnum.Hatman)
            {
                _meetHatman = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<GroundView>(out GroundView ground))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<GroundView>(out GroundView ground))
        {
            _isGround = false;
        }

        if (collision.gameObject.TryGetComponent<ICharacters>(out ICharacters character))
        {
            if (character.Character == CharactersEnum.Woman)
            {
                _meetWoman = false;
            }
            else if (character.Character == CharactersEnum.Oldman)
            {
                _meetOldman = false;
            }
            else if (character.Character == CharactersEnum.Bearded)
            {
                _meetBearded = false;
            }
            else if (character.Character == CharactersEnum.Hatman)
            {
                _meetHatman = false;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<IHouseView>(out IHouseView house))
        {
            if(house.Home == _character)
            {
                _isCanEnterHouse = true;
            }
        }

        else if(collision.transform.TryGetComponent<WellView>(out WellView well))
        {
            _isCanUseWell = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<IHouseView>(out IHouseView house))
        {
            if (house.Home == _character)
            {
                _isCanEnterHouse = false;
            }
        }

        else if (collision.transform.TryGetComponent<WellView>(out WellView well))
        {
            _isCanUseWell = false;
        }
    }
}
