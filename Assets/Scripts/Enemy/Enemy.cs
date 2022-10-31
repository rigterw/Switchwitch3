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
        if(rb.velocity.x != 0f)
        GetComponent<SpriteRenderer>().flipX = rb.velocity.x <= -0.5f;
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        velocity.x = movementSpeed;
        Debug.Log(velocity);
        rb.velocity = velocity;
    }
}
