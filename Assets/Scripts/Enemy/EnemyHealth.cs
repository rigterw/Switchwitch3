using UnityEngine;

public class EnemyHealth : HealthManager
{
    int rotationdir = 1;
    bool died = false;

    public override void Die()
    {
        base.Die();
        GetComponent<BoxCollider2D>().enabled = false;
        died = true;
    }

    void Update(){
        if(died)
        transform.Rotate(new Vector3(0, 0, 2 * rotationdir));
    }
}