using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public BoolVariable ReverseGravity;
    public const float gravity = 25f;


    /// <summary>
    /// Function that changes the gravity of all physics objects
    /// </summary>
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

    /// <summary>
    /// Function that sets the gravity force of an object
    /// </summary>
    /// <param name="obj">the object that needs to change gravity</param>
    /// <param name="newValue">the value of the gravity force</param>
    void SetGravity(GameObject obj, float newValue){
                    Rigidbody2D objBody = obj.GetComponent<Rigidbody2D>();

        if (objBody == null)
        {//check if object has a rigid body
            Debug.LogError(obj.name + " doesn't have a rigidbody to update gravity for");
            return;
        }

        objBody.gravityScale = newValue;
    }
}
