using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public BoolVariable ReverseGravity;
    public const float gravity = 25f;


    public void switchGravity(){

        ReverseGravity.value = !ReverseGravity.value;

        float newGravityValue = gravity;
        GameObject[] objects;

        if(ReverseGravity.value){
            newGravityValue = -gravity;
        }

        objects = GameObject.FindGameObjectsWithTag("GravityAffected");

        foreach (GameObject obj in objects){
            SetGravity(obj, newGravityValue);
        }

        SetGravity(GameObject.Find("Player"), newGravityValue);
    }

    void SetGravity(GameObject obj, float newValue){
                    Rigidbody2D objBody = obj.GetComponent<Rigidbody2D>();
            if(objBody == null)
                return;

            objBody.gravityScale = newValue;
    }
}
