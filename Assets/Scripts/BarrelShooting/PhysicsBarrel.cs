using UnityEngine;

public class PhysicsBarrel
{
    private BarrelView _barrelView;

    public PhysicsBarrel(BarrelView barrelView)
    {
        _barrelView = barrelView;
        _barrelView.SetVisible(false);
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        _barrelView.SetVisible(false);
        _barrelView.transform.position = position;
        _barrelView.Rigidbody.velocity = Vector2.zero;
        _barrelView.Rigidbody.angularVelocity = 0;
        _barrelView.Rigidbody.AddForce(velocity, ForceMode2D.Force);
        _barrelView.SetVisible(true);
    }
}
