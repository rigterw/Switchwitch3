using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State {
idle, walking, falling, died
}

public class StateMachine : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigibody;

    State currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        State lastState = currentState;
        currentState = GetNextState();
     
        if(currentState == lastState)
            return;

        UpdateAnimation(currentState);
    }

    /// <summary>
    /// checks the new state
    /// </summary>
    /// <returns>the next state</returns>
    State GetNextState(){
        Vector2 velocity = rigibody.velocity;
        if(velocity.y >= 2f || velocity.y <= -2f)
            return State.falling;

        if(velocity.x != 0)
            return State.walking;
        
        return State.idle;
    }


    /// <summary>
    /// function that plays the next animation
    /// </summary>
    /// <param name="nextState">the state that the animator has to switch to</param>
    void UpdateAnimation(State nextState){
        animator.SetInteger("state", (int)nextState);
    }

    public State CurrentState{
        get { return currentState; }
    }
}
