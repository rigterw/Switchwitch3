using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
///[RequireComponent(typeof(BoxCollider2D))]
public class StaticEnemy : Enemy
{
    [SerializeField] bool UpsideDown;
    protected override void SetDirection(SpriteRenderer sprite){
        sprite.flipY = UpsideDown;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale *= UpsideDown ? -1 : 1;

    }
}