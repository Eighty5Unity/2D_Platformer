using UnityEngine;

public class Barrel
{
    private BarrelView _barrelView;
    private Vector3 _velocity;

    public Barrel(BarrelView barrelView)
    {
        _barrelView = barrelView;
        _barrelView.SetVisible(false);
    }

    public void Update()
    {
        if (IsGrounded())
        {
            SetVelocity(_velocity.Change(y: -_velocity.y));
            _barrelView.transform.position = _barrelView.transform.position.Change(y: _barrelView.GroundLevel + _barrelView.Radius);
        }
        else
        {
            SetVelocity(_velocity + Vector3.up * _barrelView.Acceleration * Time.deltaTime);
            _barrelView.transform.position += _velocity * Time.deltaTime;
        }
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        _barrelView.transform.position = position;
        SetVelocity(velocity);
        _barrelView.SetVisible(true);
    }

    private bool IsGrounded()
    {
        return _barrelView.transform.position.y <= _barrelView.GroundLevel + _barrelView.Radius && _velocity.y <= 0;
    }

    private void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
        var angel = Vector3.Angle(Vector3.left, _velocity);
        var axis = Vector3.Cross(Vector3.left, _velocity);
        _barrelView.transform.rotation = Quaternion.AngleAxis(angel, axis);
    }
}
