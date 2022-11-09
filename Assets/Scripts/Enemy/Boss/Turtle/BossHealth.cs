using UnityEngine;
public class BossHealth : EnemyHealth
{
        int timer = 0;


        public int Timer {get { return timer; } }
        const int invTime = 150;
        public override void GetHit(){
        if(timer > 0)
            return;

        GetComponent<TurtleBoss>().EnterState(TurtleBoss.state.Hit);
        Debug.Log("ouch");
        timer = invTime;
        base.GetHit();
        }

    void Update(){
        if(timer > 0){
            timer--;
        }
    }
}