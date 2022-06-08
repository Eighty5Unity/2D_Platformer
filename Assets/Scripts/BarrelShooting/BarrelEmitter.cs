using System.Collections.Generic;
using UnityEngine;

public class BarrelEmitter
{
    private const float DELAY = 1f;
    private const float STARTSPEED = 1f;

    private List<Barrel> _barrels = new List<Barrel>();
    private Transform _transform;
    private int _currentIndex;
    private float _timeTillNextBullet;

    public BarrelEmitter(List<BarrelView> barrelViews, Transform transform)
    {
        _transform = transform;
        foreach(var barrelView in barrelViews)
        {
            _barrels.Add(new Barrel(barrelView));
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
        _barrels.ForEach(b => b.Update());
    }
}
