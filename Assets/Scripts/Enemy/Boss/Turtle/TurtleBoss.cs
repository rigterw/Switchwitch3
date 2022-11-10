using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurtleStates;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BossHealth))]
[RequireComponent(typeof(TurtleGravity))]
public class TurtleBoss : Enemy
{
    public enum state{
        Idle, Blue, Red, Hit
    }
    state eCurrentState;

    public state ECurrentState {get { return eCurrentState; } }
    State currentState;
    Rigidbody2D rb;
    Animator animator;
    Dictionary<state, State> states = new Dictionary<state, State>();
    public float speed;

    public BoolVariable gravity;
    TurtleGravity gravityUpdater;
    BossHealth bosshealth;
    SpriteRenderer sprite;
    protected override void Start()
    {
        GameObject player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gravityUpdater = GetComponent<TurtleGravity>();
        bosshealth = GetComponent<BossHealth>();
         sprite = GetComponent<SpriteRenderer>();



        states.Add(state.Blue, new BlueState(sprite, player.transform));
        states.Add(state.Red, new RedState(sprite, player.transform));
        states.Add(state.Idle, new IdleState(sprite, player.transform));
        states.Add(state.Hit, new HitState(sprite, player.transform, animator, transform.Find("bounceCheck"), bosshealth));

        EnterState(state.Idle);

        base.Start();
    }

    /// <summary>
    /// function that sets free the boss
    /// </summary>
    public void Activate(){
        Debug.Log("beast has awaken");

        StartCoroutine(SwitchLoop());
    }

    void Update(){
        currentState.Update();
        if(eCurrentState == state.Hit && bosshealth.Timer < 0){
            Activate();
        }
        sprite.flipX = rb.velocity.x > 0;

    }

    void FixedUpdate(){
        rb.AddForce(currentState.calculateForce(this.transform)* speed);
    }

    /// <summary>
    /// switches the state every x seconds
    /// </summary>
    /// <param name="healthManager">the healthmanager of the boss</param>
    IEnumerator SwitchLoop(){

        while (bosshealth.Health > 0)
        {
            Debug.Log("update");
            Switch();
            yield return new WaitForSeconds(5);
        }
    }

    /// <summary>
    /// function the switch to a different state
    /// </summary>
    /// <param name="newState">target state</param>
    public void EnterState(state newState){
        currentState = states[newState];
        eCurrentState = newState;
        currentState.Enter();
        gravityUpdater.ChangeGravity(gravity.value);
        if (newState == state.Hit)
        {
            StopCoroutine(SwitchLoop());
        }
            animator.SetInteger("State", (int)eCurrentState);

    }

    /// <summary>
    /// function that switches the state from blue to red or back
    /// </summary>
    public void Switch(){
        if(eCurrentState == state.Blue){
            EnterState(state.Red);
        }else{
            EnterState(state.Blue);
        }
    }

}
