using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Controls playerInput;
    InputAction move;
    InputAction Power;
    InputAction UpDown;
    public BoolVariable reverseGravity;

    Rigidbody2D rigidBody;
    public float movementSpeed;
    Vector2 moveValue;
    // Start is called before the first frame update
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
        UpDown.Enable();

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
    }


    void HandleGravity(){
        if(UpDown.ReadValue<float>() == -1 + 2*Convert.ToInt32(reverseGravity.value))
            return;

        GameObject level = GameObject.Find("Level");
        level.GetComponent<GravityController>().switchGravity();
    }
    /// <summary>
    /// function that activates the current power
    /// </summary>
    void UsePower(InputAction.CallbackContext context){
        Debug.Log(context.ToString());
    }
}
