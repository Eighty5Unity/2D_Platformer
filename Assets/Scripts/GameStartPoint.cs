using System.Collections.Generic;
using UnityEngine;

public class GameStartPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private SpriteAnimationConfig[] _spriteAnimationConfig;

    private ParalaxManager _paralaxManager;
    private List<SpriteAnimation> _spriteAnimations = new List<SpriteAnimation>();
    private PlayerController _playerController;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);

        for(int i = 0; i < _characterView.Length; i++)
        {
            var currentPerson = new SpriteAnimation(_spriteAnimationConfig[i]);
            currentPerson.StartAnimation(_characterView[i].SpriteRenderer, CharacterAnimationTracks.idle, true, 8); // change to different characters
            _spriteAnimations.Add(currentPerson);
        }

        _playerController = new PlayerController(_characterView[0], _spriteAnimations[0]);
    }

    private void Update()
    {
        _paralaxManager.Update();

        foreach(var spriteAnimation in _spriteAnimations)
        {
            spriteAnimation.Update();
        }

        _playerController.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
