using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player;

public class Book : MonoBehaviour
{
    [SerializeField]Element element;

    void OnCollisionEnter2D(Collision2D other){
        
        if(!other.gameObject.CompareTag("Player"))
            return;

        other.gameObject.GetComponent<StateMachine>().SwitchElements(element);
        Destroy(gameObject);
    }
}
