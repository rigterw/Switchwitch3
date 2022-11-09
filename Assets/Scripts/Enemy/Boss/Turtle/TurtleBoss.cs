using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurtleStates;


public class TurtleBoss : Enemy
{
    protected enum state{
        Idle, Red, Blue
    }
    SpriteRenderer sprite;
    state eCurrentState;
    State currentState;
    Rigidbody2D rb;
    Dictionary<state, State> states = new Dictionary<state, State>();

    protected override void Start()
    {
        GameObject player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        states.Add(state.Blue, new BlueState(sprite, player.transform));
        states.Add(state.Red, new RedState(sprite, player.transform));
        states.Add(state.Idle, new IdleState(sprite, player.transform));
        currentState = states[eCurrentState];

        base.Start();
    }

    void update(){
        currentState.Update();
    }

    void FixedUpdate(){
        rb.AddForce(currentState.calculateForce(this.transform));
    }

    void EnterState()

    public void Switch(){
        if(eCurrentState == state.Blue){
            eCurrentState = state.Red;
        }else{
            eCurrentState = state.Blue;
        }
        currentState = states[eCurrentState];
        currentState.Enter();
    }

}
