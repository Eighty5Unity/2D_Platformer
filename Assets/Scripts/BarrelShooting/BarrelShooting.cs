using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelShooting : IUpdate, IFixedUpdate
{
    private Transform _shootingStartPoint;
    private WellView _well;
    private BarrelFactory _barrelFactory;
    public BarrelFactory BarrelFactory => _barrelFactory;
    private float _timeTillNextShoot = 1f;
    private List<BarrelView> _barrelViews = new List<BarrelView>();

    public BarrelShooting(BarrelView barrelView, WellView well)
    {
        _barrelFactory = new BarrelFactory(barrelView.gameObject);
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
                _barrelFactory.Destroy(barrel);
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
            _timeTillNextShoot = 1f;
            var barrel = _barrelFactory.GetBarrel(_shootingStartPoint.position, _shootingStartPoint.rotation);
            barrel.Rigidbody.AddForce(new Vector2(_well.LeftRight, _well.DownUp), ForceMode2D.Impulse);
            _barrelViews.Add(barrel);
        }
    }
}
