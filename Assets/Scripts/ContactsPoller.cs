using UnityEngine;

public class ContactsPoller
{
    private const float _collisionTresh = 0.01f;
    private ContactPoint2D[] _contacts = new ContactPoint2D[4];
    private Collider2D _collider;

    public bool IsGrounded { get; private set; }
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }

    public ContactsPoller(Collider2D collider)
    {
        _collider = collider;
    }

    public void Update()
    {
        IsGrounded = false;
        HasLeftContacts = false;
        HasRightContacts = false;

        var contactCount = _collider.GetContacts(_contacts);

        for (var i = 0; i < contactCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigidbody = _contacts[i].rigidbody;

            if (normal.y > _collisionTresh)
                IsGrounded = true;

            if (normal.x > _collisionTresh && rigidbody != null)
                HasLeftContacts = true;

            if (normal.x < -_collisionTresh && rigidbody != null)
                HasRightContacts = true;
        }
    }
}
