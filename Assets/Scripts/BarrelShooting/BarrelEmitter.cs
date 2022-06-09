using System.Collections.Generic;
using UnityEngine;

public class BarrelEmitter
{
    private const float DELAY = 3f;
    private const float STARTSPEED = 3f;

    private List<PhysicsBarrel> _barrels = new List<PhysicsBarrel>();
    private Transform _transform;
    private int _currentIndex;
    private float _timeTillNextBullet;

    public BarrelEmitter(List<BarrelView> barrelViews, Transform transform)
    {
        _transform = transform;
        foreach(var barrelView in barrelViews)
        {
            _barrels.Add(new PhysicsBarrel(barrelView));
        }
    }

    public void Update()
    {
        if(_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            _timeTillNextBullet = DELAY;
            _barrels[_currentIndex].Throw(_transform.position, _transform.up * STARTSPEED);
            _currentIndex++;

            if(_currentIndex >= _barrels.Count)
            {
                _currentIndex = 0;
            }
        }
    }
}
