using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : HealthManager
{

    int timer = 0;
    const int invTime = 150;
    GameObject Lives;
    List<GameObject> lives = new List<GameObject>();

    SpriteRenderer sprite;

     void Start(){
        health = MAXHEALTH;
        sprite = GetComponent<SpriteRenderer>();
        Transform LivesHolder = GameObject.Find("LivesUI").transform;

        foreach (Transform life in LivesHolder){
            lives.Add(life.gameObject);
        }


    }
    void FixedUpdate(){
        if(timer > 0){
            timer--;
            Flash();
        }
        OutOfBoundsCheck();
    }

    public override void GetHit(){
        if(timer > 0)
            return;
        
        lives[health -1].SetActive(false);

        timer = invTime;
        base.GetHit();
    }

    public override void Die(){
        base.Die();
        SceneManager.LoadScene("GameOverScene");

    }

    public override void Heal(){
        base.Heal();
        lives[health -1].SetActive(true);

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