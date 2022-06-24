using System.Collections.Generic;
using UnityEngine;

public class BarrelShooting : IUpdate, IFixedUpdate
{
    private Transform _shootingStartPoint;
    private BarrelShootingView _shootingPoint;
    private BarrelFactory _barrelFactory;
    private BarrelCrashFactory _barrelCrashFactory;
    private float _timeTillNextShoot = 3f;
    private List<BarrelView> _barrelViews = new List<BarrelView>();
    private List<ParticleSystem> _barrelParticleSystems = new List<ParticleSystem>();
    private CharacterView _bearded;
    private GameTask _gameTask;
    private int _countOfBarrelInWagon;

    public BarrelShooting(BarrelView barrelView, BarrelShootingView shootingView, GameObject barrelCrashEffect, CharacterView[] characters, GameTask task)
    {
        _barrelFactory = new BarrelFactory(barrelView.gameObject);
        _barrelCrashFactory = new BarrelCrashFactory(barrelCrashEffect);
        _shootingPoint = shootingView;
        _shootingStartPoint = _shootingPoint.BarrelShootPoint;
        _gameTask = task;

        foreach(var bearded in characters)
        {
            if(bearded.CharacterEnum == CharactersEnum.Bearded)
            {
                _bearded = bearded;
            }
        }
    }

    public void Update(float deltaTime)
    {
        foreach(var barrel in _barrelViews)
        {
            if (barrel.IsGround)
            {
                barrel.IsGround = false;
                var position = barrel.transform.position;
                var rotation = barrel.transform.rotation;
                var crashEffect = _barrelCrashFactory.GetBarrelCrashEffect(position, rotation);
                crashEffect.Play();
                _barrelParticleSystems.Add(crashEffect);
                _barrelFactory.Destroy(barrel);
                _barrelViews.Remove(barrel);
                break;
            }
            else if (barrel.IsWagon && !_gameTask.TaskForBeardedFillWagon)
            {
                _countOfBarrelInWagon++;
                if (_countOfBarrelInWagon == 10)//make field how many counts we need
                {
                    _gameTask.TaskForBeardedFillWagon = true;
                }

                barrel.IsWagon = false;
                _barrelFactory.Destroy(barrel);
                _barrelViews.Remove(barrel);
                break;
            }
        }

        foreach(var effect in _barrelParticleSystems)
        {
            if (!effect.isPlaying)
            {
                _barrelCrashFactory.Destroy(effect);
                _barrelParticleSystems.Remove(effect);
                break;
            }
        }
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        if (!_bearded.IsAtHouse)
        {
            return;
        }

        if(_timeTillNextShoot > 0)
        {
            _timeTillNextShoot -= fixedDeltaTime;
        }
        else
        {
            _timeTillNextShoot = 3f;
            var barrel = _barrelFactory.GetBarrel(_shootingStartPoint.position, _shootingStartPoint.rotation);
            barrel.Rigidbody.AddForce(new Vector2(_shootingPoint.LeftRight, _shootingPoint.DownUp), ForceMode2D.Impulse);
            _barrelViews.Add(barrel);
        }
    }
}
