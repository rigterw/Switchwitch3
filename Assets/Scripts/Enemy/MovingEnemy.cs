using UnityEngine;

public class MovingEnemy :Enemy {

    Vector2 velocity;
    [SerializeField] float movementSpeed;
    public bool bounce;//bool if the enemy should turn around when hitting a wall
    [SerializeField] Transform bouncePoint;
    float bounceCheckDistance = 0.15f;//distance of the range of the flip point

    Rigidbody2D rb;


    protected override void SetDirection(SpriteRenderer sprite){
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = movementSpeed > 0;

        if(!isFacingRight)
            bouncePoint.localPosition = new Vector2(-bouncePoint.localPosition.x, bouncePoint.localPosition.y);
        sprite.flipX = !isFacingRight;
    }

        // Update is called once per frame
    void Update()
    {
        if(bounce)
            Bounce();
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        velocity.x = movementSpeed;
        rb.velocity = velocity;
    }

    /// <summary>
    /// function that makes the enemy turn around
    /// </summary>
    void Flip(){
        movementSpeed = -movementSpeed;
        bouncePoint.localPosition = new Vector2(-bouncePoint.localPosition.x, bouncePoint.localPosition.y);
        isFacingRight = movementSpeed > 0f;
        //sets the sprite direction according to the velocity
        GetComponent<SpriteRenderer>().flipX = !isFacingRight;
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
            Flip();
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