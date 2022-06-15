using UnityEngine;

public class BarrelView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _isGround;
    private bool _isWagon;
    
    public Rigidbody2D Rigidbody => _rigidbody;
    public bool IsGround { get => _isGround; set => _isGround = value; }
    public bool IsWagon { get => _isWagon; set => _isWagon = value; }

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<GroundView>(out GroundView ground))
        {
            _isGround = true;
        }
        else if(collision.transform.TryGetComponent<WagonView>(out WagonView wagon))
        {
            _isWagon = true;
        }
    }
}
