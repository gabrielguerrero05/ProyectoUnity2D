using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500f;
    public float maxLifetime = 10f;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction, float speed)
    {
        _rigidbody.velocity = direction * speed;
        Destroy (gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
