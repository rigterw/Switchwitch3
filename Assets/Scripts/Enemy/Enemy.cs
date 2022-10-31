using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    public bool bounce;
    bool isFacingRight = true;
    Vector2 velocity;
    Rigidbody2D rb;

    [SerializeField]
    Transform bouncePoint;
    float bounceCheckDistance = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.x > 0.1f || rb.velocity.x < -0.1f)
            isFacingRight = rb.velocity.x > 0f;
        
        if(bounce)
            Bounce();

        //sets the sprite direction according to the velocity
        GetComponent<SpriteRenderer>().flipX = !isFacingRight;
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        velocity.x = movementSpeed;
        rb.velocity = velocity;
    }


    /// <summary>
    /// function that changes the movement direction when hitting a wall
    /// </summary>
    void Bounce(){
        if (bouncePoint == null) { 
            Debug.LogError("No bouncePoint given"); 
            return; 
        }

        if(BounceCheck()){
            movementSpeed = -movementSpeed;
            bouncePoint.localPosition = new Vector2(-bouncePoint.localPosition.x, bouncePoint.localPosition.y);
        }
    }


    /// <summary>
    /// function that checks if enemy is hitting a wall
    /// </summary>
    /// <returns>true if the player hits a wall</returns>
    bool BounceCheck(){
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallHit = Physics2D.Raycast(bouncePoint.position, direction, bounceCheckDistance, LayerMask.GetMask("world"));
        bool shouldBounce = wallHit.collider != null;


        return shouldBounce;
    }

}
