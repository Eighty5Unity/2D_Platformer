using System.Collections.Generic;
using UnityEngine;

public class GameStartPoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private WellView _wellView;
    [SerializeField] private List<BarrelView> _barrelViews;
    [SerializeField] private Transform _muzzleTransform;
    //CoinViewList

    
    private PlayerPhysicsController _playerController;
    private BarrelEmitter _barrelEmitter;
    private AimingMuzzle _aimingMuzzle;
    private ChangePlayerController _changePlayerController;
    //CoinsManager

    private void Start()
    {
        //for(int i = 0; i < _characterView.Length; i++)
        //{
        //    var currentPerson = new SpriteAnimation(_characterView[i].SpriteAnimationConfig);
        //    currentPerson.StartAnimation(_characterView[i].SpriteRenderer, CharacterAnimationTracks.idle, _characterView[i].AnimationLoop, _characterView[i].AnimationSpeed); 
        //    //_spriteAnimations.Add(currentPerson);
        //}
        //_playerController = new PlayerPhysicsController(_characterView[0], _spriteAnimations[0]);
        //_changePlayerController = new ChangePlayerController(_characterView, _playerController);
        _aimingMuzzle = new AimingMuzzle(_wellView.transform, _changePlayerController.CurrentCharacter.transform);
        _barrelEmitter = new BarrelEmitter(_barrelViews, _muzzleTransform.transform);
    }

    private void Update()
    {
        //_changePlayerController.Update();
        _aimingMuzzle.Update();
        _barrelEmitter.Update();
    }

    private void FixedUpdate()
    {
        //_playerController.FixedUpdate();
    }

    private void OnDestroy()
    {
        
    }
}
