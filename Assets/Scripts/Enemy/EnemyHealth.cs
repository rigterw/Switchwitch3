using UnityEngine;

public class EnemyHealth : HealthManager
{
    int rotationdir = 1;
    bool died = false;

    public override void Die()
    {
        base.Die();
        died = true;
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 5);

    }

    void FixedUpdate(){
        if(!died)
            return;
        
        //starts rotating when dead
        transform.Rotate(new Vector3(0, 0, 5 * rotationdir));
    }
    
}