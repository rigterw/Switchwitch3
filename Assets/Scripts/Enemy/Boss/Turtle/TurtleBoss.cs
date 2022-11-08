using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurtleBoss : Enemy
{

    [SerializeField] bool isBlueState;

    SpriteRenderer sprite;
    State currentState;
    Rigidbody2D rb;
    Dictionary<bool, State> states = new Dictionary<bool, State>();

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        states.Add(true, new BlueState(sprite));
        states.Add(false, new RedState(sprite));
        currentState = states[isBlueState];

        base.Start();
    }

    void update(){
        currentState.Update();
    }

    void FixedUpdate(){
        rb.AddForce(currentState.calculateForce());
    }

    public void Switch(){
        isBlueState = !isBlueState;
        currentState = states[isBlueState];
        currentState.Enter();
    }

}
