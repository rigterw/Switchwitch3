using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Controls playerInput;
    InputAction move;
    InputAction fire;
    InputAction up, down;


    Rigidbody rigidBody;
    public Vector2 velocity;
    Vector2 moveValue;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Awake(){
        playerInput = new Controls();
    }

    void OnEnable(){
        move = playerInput.player.Move;
        move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = move.ReadValue<Vector2>();
    }

    void FixedUpdate(){
        rigidBody.velocity = moveValue * velocity;
    }
}
