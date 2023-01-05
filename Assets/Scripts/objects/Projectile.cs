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
}
