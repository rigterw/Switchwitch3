using UnityEngine;



public class EnemyDamagePlayer : DamagePlayer{
    protected override void Damage(Collider2D other){
        if(other.CompareTag("Enemy"))
            return;
        base.Damage( other);
    }
}