
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class GravityUpdater : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// function that changes the gravity
    /// </summary>
    /// <param name="isReversed">if gravity is normal or the other way around</param>
    public virtual void ChangeGravity(bool isReversed){
        rb.gravityScale = isReversed ? -GravityController.gravity : GravityController.gravity;
        GetComponent<SpriteRenderer>().flipY = isReversed;
    }

    
}
