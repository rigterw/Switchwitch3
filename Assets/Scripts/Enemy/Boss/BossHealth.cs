using System.Collections;
using UnityEngine;
public class BossHealth : EnemyHealth
{
    [SerializeField] GameObject drop;
    int timer = 0;


    public int Timer {get { return timer; } }
    const int invTime = 150;
    public override void GetHit(){
    if(timer > 0)
        return;

    GetComponent<TurtleBoss>().EnterState(TurtleBoss.state.Hit);
    timer = invTime;
    base.GetHit();
    }

    public override void Die()
    {
        StartCoroutine(spawnDrop());
        base.Die();	
    }

    IEnumerator spawnDrop(){
        yield return new WaitForSeconds(3);
        drop.SetActive(true);
    }

    void Update(){
        if(timer > 0){
            timer--;
        }
    }
}