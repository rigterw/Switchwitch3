using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject preFabBG;//the background that needs to be spawned

    Transform position;
    Transform playerPos;
    float nextSpawnValue;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
        playerPos = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = position.position;
        if(pos.x > position.position.x){
            pos.x++;
        }



        
    }
}
