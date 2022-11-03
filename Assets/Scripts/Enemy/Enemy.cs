using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool facingLeft;
    protected bool isFacingRight;//bool keeping track of the sprite direction

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetDirection();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void SetDirection(){
        GetComponent<SpriteRenderer>().flipX = facingLeft;
        isFacingRight = !facingLeft;
    }



}
