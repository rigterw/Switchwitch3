using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public BoolVariable ReverseGravity;
    public const float gravity = 1f;


    /// <summary>
    /// Function that changes the gravity of all physics objects
    /// </summary>
    public void switchGravity(){

        ReverseGravity.value = !ReverseGravity.value;

        List<GameObject> objects;


        objects = CustomTags.FindGameObjectsWithTag(Tag.gravityAffected);

        foreach (GameObject obj in objects){
            SetGravity(obj);
        }

    }

    /// <summary>
    /// Function that sets the gravity force of an object
    /// </summary>
    /// <param name="obj">the object that needs to change gravity</param>
    void SetGravity(GameObject obj){
        GravityUpdater objGravityUpdater = obj.GetComponent<GravityUpdater>();

        if (objGravityUpdater == null)
        {//check if object has a rigid body
            Debug.LogError(obj.name + " doesn't have a GravityUpdater to update gravity for");
            return;
        }

        objGravityUpdater.ChangeGravity(ReverseGravity.value);
    }
}
