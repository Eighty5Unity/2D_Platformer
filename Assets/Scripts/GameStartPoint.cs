using System.Collections.Generic;
using UnityEngine;

public class GameStartPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private WellView _wellView;
    [SerializeField] private List<BarrelView> _barrelViews;
    [SerializeField] private Transform _muzzleTransform;

    private ParalaxManager _paralaxManager;
    private List<SpriteAnimation> _spriteAnimations = new List<SpriteAnimation>();
    private PlayerController _playerController;
    private BarrelEmitter _barrelEmitter;
    private AimingMuzzle _aimingMuzzle;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);

        for(int i = 0; i < _characterView.Length; i++)
        {
            var currentPerson = new SpriteAnimation(_characterView[i].SpriteAnimationConfig);
            currentPerson.StartAnimation(_characterView[i].SpriteRenderer, CharacterAnimationTracks.idle, _characterView[i].AnimationLoop, _characterView[i].AnimationSpeed); 
            _spriteAnimations.Add(currentPerson);
        }

        _playerController = new PlayerController(_characterView[0], _spriteAnimations[0]); // change to different characters
        _aimingMuzzle = new AimingMuzzle(_wellView.transform, _characterView[0].transform);
        _barrelEmitter = new BarrelEmitter(_barrelViews, _muzzleTransform.transform);
    }

    private void Update()
    {
        _paralaxManager.Update();

        foreach(var spriteAnimation in _spriteAnimations)
        {
            spriteAnimation.Update();
        }

        _playerController.Update();
        _aimingMuzzle.Update();
        _barrelEmitter.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
