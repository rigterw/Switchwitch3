using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 velocity;
    Transform sender;
    public void Launch(Vector3 velocity, Transform sender){
        this.velocity = velocity/100;
        this.sender = sender;
        this.transform.position = sender.position;
    }

    private void Update(){
        transform.position += velocity;
    }

    private void OnTriggerEnter2D(Collider2D other){
        //firendly fire check
        if(other.transform == sender)
            return;
        
        //damages the object it collides with
        HealthManager otherHealth = other.GetComponent<HealthManager>();
        if(otherHealth != null)
            otherHealth.GetHit();

        Destroy(this.gameObject);

    }
}
