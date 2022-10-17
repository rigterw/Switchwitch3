using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    //variables for controls
    public Controls playerInput;
    InputAction move;
    InputAction Power;
    InputAction UpDown;
    //variables for movement
    public float movementSpeed;
    Vector2 moveValue;

    //variables for gravity handling
    bool onGround;
    public BoolVariable reverseGravity;
    Rigidbody2D rigidBody;




    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Awake(){
        playerInput = new Controls();
    }

    void OnEnable(){
        move = playerInput.player.Move;
        move.Enable();

        Power = playerInput.player.UsePower;
        Power.Enable();
        Power.performed += UsePower;

        UpDown = playerInput.player.UpDown;
        UpDown.Enable();

    }

    void OnDisable(){
        move.Disable();
        Power.Disable();
        UpDown.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        moveValue = move.ReadValue<Vector2>();
        if(UpDown.ReadValue<float>() == -1 + 2*Convert.ToInt32(reverseGravity.value) ){
            //sneak
        }else if(UpDown.ReadValue<float>() != 0){
            HandleGravity();
        }
    }

    void FixedUpdate(){
        rigidBody.velocity = moveValue * movementSpeed;

        //flips the sprite x-as
        if(moveValue.x != 0)
        GetComponent<SpriteRenderer>().flipX = rigidBody.velocity.x <= -1f;
    }

    /// <summary>
    /// function that switches the levels gravity
    /// </summary>
    void HandleGravity(){
        if(!onGround)
            return;
        GameObject level = GameObject.Find("Level");
        level.GetComponent<GravityController>().switchGravity();
        GetComponent<SpriteRenderer>().flipY = reverseGravity.value;
    }

    /// <summary>
    /// function that activates the current power
    /// </summary>
    void UsePower(InputAction.CallbackContext context){
        Debug.Log(context.ToString());
    }


    public Vector2 MovementValue {
        get { return moveValue * movementSpeed; }
    }


    void OnCollisionStay2D(Collision2D collider){
        if(collider.gameObject.GetComponent<CustomTags>().hasTag(Tag.surface)){
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider){
                if(collider.gameObject.GetComponent<CustomTags>().hasTag(Tag.surface)){
            onGround = false;
        }
    }
}
