using UnityEngine;

public class BarrelView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [SerializeField] private float _radius = 0.3f;
    [SerializeField] private float _groundLevel = 0f;
    [SerializeField] private float _acceleration = -10f;

    public float Radius => _radius;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}
