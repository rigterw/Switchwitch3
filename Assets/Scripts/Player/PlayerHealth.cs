using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthManager
{

    int timer = 0;
    const int invTime = 150;

    SpriteRenderer sprite;

    public override void GetHit(){
        if(timer > 0)
            return;
        
        GameObject.Find("life" + health).SetActive(false);

        timer = invTime;
        base.GetHit();
    }

    void start(){
        health = MAXHEALTH;
    }

    public override void Die(){
        base.Die();
        SceneManager.LoadScene("GameOverScene");

    }

    public override void Heal(){
        base.Heal();
        GameObject.Find("life" + health).SetActive(true);

    }

     void Start(){
        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate(){
        if(timer > 0){
            timer--;
            Flash();
        }
        OutOfBoundsCheck();
    }
    
    void Flash(){
        if(timer % 30 == 0){
            sprite.color = new Color(255,255,255);
        }else if(timer %15 == 0){
            sprite.color = new Color(255,0,0);
        }
    }

    void OutOfBoundsCheck(){
        if(transform.position.y < -5 || transform.position.y > 10)
            Die();
    }
}