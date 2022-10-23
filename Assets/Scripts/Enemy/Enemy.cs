using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    Vector2 velocity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = rb.velocity.x <= -1f;
    }

    void FixedUpdate()
    {
        velocity = Vector2.zero;
        velocity.x += movementSpeed;
        Debug.Log(velocity);
        rb.AddForce(velocity, ForceMode2D.Impulse);
    }
}
