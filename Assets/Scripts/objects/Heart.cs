using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    float animationSpeed = 0.0025f;//speed of the rotation animation

    /// <summary>
    /// function that tries to give healing to object that collides
    /// </summary>
    /// <param name="other">object that collides</param>
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("boink");
        HealthManager playerHealth = other.gameObject.GetComponent<HealthManager>();
        if(playerHealth == null)
            return;

        playerHealth.Heal();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(animationSpeed, 0, 0);
        if(transform.localScale.x < -1 || transform.localScale.x > 1)
            transform.localScale = new Vector3(1, 1, 1);
    }
}
