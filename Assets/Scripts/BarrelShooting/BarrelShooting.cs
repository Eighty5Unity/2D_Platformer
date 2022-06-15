using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelShooting : IUpdate, IFixedUpdate
{
    private Transform _shootingStartPoint;
    private WellView _well;
    private BarrelFactory _barrelFactory;
    private BarrelCrashFactory _barrelCrashFactory;
    private float _timeTillNextShoot = 0.1f;
    private List<BarrelView> _barrelViews = new List<BarrelView>();
    private List<ParticleSystem> _barrelParticleSystems = new List<ParticleSystem>();

    public BarrelShooting(BarrelView barrelView, WellView well, GameObject barrelCrashEffect)
    {
        _barrelFactory = new BarrelFactory(barrelView.gameObject);
        _barrelCrashFactory = new BarrelCrashFactory(barrelCrashEffect);
        _shootingStartPoint = well.BarrelShootPoint;
        _well = well;
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
        if(_timeTillNextShoot > 0)
        {
            _timeTillNextShoot -= fixedDeltaTime;
        }
        else
        {
            _timeTillNextShoot = 0.5f;
            var barrel = _barrelFactory.GetBarrel(_shootingStartPoint.position, _shootingStartPoint.rotation);
            barrel.Rigidbody.AddForce(new Vector2(_well.LeftRight, _well.DownUp), ForceMode2D.Impulse);
            _barrelViews.Add(barrel);
        }
    }
}
