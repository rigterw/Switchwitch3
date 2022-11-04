
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class GravityUpdater : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void ChangeGravity(bool isReversed){
        rb.gravityScale = isReversed ? -GravityController.gravity : GravityController.gravity;
        GetComponent<SpriteRenderer>().flipY = isReversed;
    }

    
}
