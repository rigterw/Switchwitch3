using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool facingLeft;
    protected bool isFacingRight;//bool keeping track of the sprite direction

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetDirection(GetComponent<SpriteRenderer>());
    }



    /// <summary>
    /// sets the direction of the sprites
    /// </summary>
    protected virtual void SetDirection(SpriteRenderer sprite){
        sprite.flipX = facingLeft;
        isFacingRight = !facingLeft;
    }



}
