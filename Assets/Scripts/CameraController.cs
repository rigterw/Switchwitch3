using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables used to spawn backgrounds
    [SerializeField]
    List<GameObject> backgrounds;
    public GameObject preFabBG;//the background that needs to be spawned
    float nextSpawnValue;//the value for when the camera needs to spawn a new background
    Vector2 imgSize;


    //variables for the camera speed calculation
    Transform position;//position of the camera
    Transform playerPos;//position of the player the camera has to follow
    Rigidbody2D Rbody;//rigidBody of the player the camera has to follow
    float playerDirection;//value of the player direction (-1 for left, 1 for right)

    void Start()
    {
        position = GetComponent<Transform>();
        GameObject player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();
        Rbody = player.GetComponent<Rigidbody2D>();

        backgrounds = new List<GameObject>();
        GameObject firstBG = GameObject.Find("background");
        backgrounds.Add(firstBG);

        Transform Imgtransform = firstBG.transform.GetChild(0);
        SpriteRenderer imgrender = Imgtransform.GetComponent<SpriteRenderer>();
        imgSize = imgrender.bounds.size;
    }


    void Update()
    {
        ExtendBackGround();
    }

    void FixedUpdate(){
        MoveCamera();
    }


    /// <summary>
    /// Function that lets the camera follow the player
    /// </summary>
    void MoveCamera(){
        //updates the direction upon movement
        if(Rbody.velocity.x != 0.0)
            playerDirection = Rbody.velocity.x < 0 ? -1 : 1;

        //calculates the camera speed
        Vector3 power = (playerPos.position + new Vector3(5,0,0)*playerDirection - position.position) / 80;

        //moves the camera
        position.position += new Vector3(power.x, 0,0);
        if(position.position.x < 0){
            position.position = new Vector3(0, position.position.y, position.position.z);
        }
    }

    /// <summary>
    /// function that spawns a new background every time the camera gets to the lasts backgrounds edge
    /// </summary>
    void ExtendBackGround(){
    //check if the camera is near the edge
    if(position.position.x < nextSpawnValue)
        return;
    
    nextSpawnValue += imgSize.x - 0.1f;
    GameObject lastBG = backgrounds.Last();
    Vector3 lastBGPos = lastBG.GetComponent<Transform>().position;
    Instantiate(preFabBG, new Vector3(lastBGPos.x + nextSpawnValue, lastBGPos.y, 0), Quaternion.identity);
    }

        
}

