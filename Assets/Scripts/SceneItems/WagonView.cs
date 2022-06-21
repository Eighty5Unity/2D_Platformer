using UnityEngine;

public class WagonView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<HatmanView>(out HatmanView hatman))
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<HatmanView>(out HatmanView hatman))
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }
    }
}
