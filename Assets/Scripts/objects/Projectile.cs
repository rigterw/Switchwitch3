using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 velocity;
    private Transform sender;

    [SerializeField] private float despawnTime = 8;

    public void Launch(Vector3 velocity, Transform sender){
        this.velocity = velocity/100;
        this.sender = sender;
        this.transform.position = sender.position;

        StartCoroutine(Despawn(despawnTime));
    }



    /// <summary>
    /// despawns the bullet after specified amount of time
    /// </summary>
    /// <param name="time">the time the bullet stays alive</param>
    private IEnumerator Despawn(float time){
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
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
