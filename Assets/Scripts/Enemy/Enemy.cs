using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool facingLeft;
    [SerializeField] bool leftFacingSprite;
    protected bool isFacingRight;//bool keeping track of the sprite direction

    public bool IsFacingRight { get { return isFacingRight; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetDirection(GetComponent<SpriteRenderer>());
    }



    /// <summary>
    /// sets the direction of the sprites
    /// </summary>
    protected virtual void SetDirection(SpriteRenderer sprite){
        sprite.flipX = facingLeft && !leftFacingSprite || leftFacingSprite && !facingLeft;
        isFacingRight = !facingLeft;
    }



}
