using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tag{
    surface, gravityAffected, playerPassable
}
public class CustomTags : MonoBehaviour
{
    [SerializeField]
    private List<Tag> tags = new List<Tag>();


    /// <summary>
    /// returns if this object has a specific tag
    /// </summary>
    /// <param name="tag">the tag you're searching for</param>
    /// <returns>true if tag is present</returns>
    public bool hasTag(Tag tag){
        return tags.Contains(tag);
    }

    /// <summary>
    /// finds all the objects with a certain tag
    /// </summary>
    /// <param name="tag">the tag you're searching for</param>
    /// <returns>a list of objects containing this tag</returns>
    public static List<GameObject> FindGameObjectsWithTag(Tag tag){
    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> objects = new List<GameObject>();

        foreach (GameObject obj in allObjects){
            CustomTags tags = obj.GetComponent<CustomTags>();
            if(tags == null){
                continue;
            }
            if(tags.hasTag(tag))
                objects.Add(obj);
        }

        return objects;
    }
}
