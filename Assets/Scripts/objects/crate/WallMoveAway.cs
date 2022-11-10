using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveAway : MonoBehaviour
{
    public Rigidbody2D rb;
    void OnTriggerStay2D(Collider2D other){

        if(!other.CompareTag("Grid"))
            return;

        RaycastHit2D wallhit = Physics2D.Raycast(transform.position, new Vector2(1,0), 3, LayerMask.GetMask("world"));
        Vector2 moveforce = new Vector2(30, 0);
        if(wallhit){
            moveforce *= -1;
        }

        rb.AddForce(moveforce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
