using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{

    [SerializeField]UnityEvent activator;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(!other.CompareTag("Player"))
            return;
        activator.Invoke();
    }

    void OnCollisionEnter2D(Collision2D other){
                if(!other.gameObject.CompareTag("Player"))
            return;
        activator.Invoke();
    }
}
