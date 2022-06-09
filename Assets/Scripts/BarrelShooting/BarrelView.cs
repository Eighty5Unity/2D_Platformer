using UnityEngine;

public class BarrelView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}
