using TurtleStates;
using UnityEngine;
public class TurtleGravity : GravityUpdater
{

    public TurtleBoss statemachine;

    protected override void Start()
    {
        statemachine = GetComponent<TurtleBoss>();
        base.Start();
    }

    public override void ChangeGravity(bool isReversed)
    {
        if(statemachine.ECurrentState != TurtleBoss.state.Red){
            return;
        }
        base.ChangeGravity(isReversed);
    }

}