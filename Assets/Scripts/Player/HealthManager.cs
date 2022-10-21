using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int health = 3;
    int timer = 0;
    const int invTime = 150;

    SpriteRenderer sprite;
    Transform trans;


    /// <summary>
    /// function that kills the player
    /// </summary>
    public void Die(){
        health = 0;
        SceneManager.LoadScene("GameOverScene");
        
    }
    public int Health {
        get  => health;
    }


    /// <summary>
    /// function that makes the player lose a life
    /// </summary>
    public void GetHit(){
        if(timer > 0)
            return;
        GameObject.Find("life" + health).SetActive(false);
        health--;

        if(health <= 0)
            Die();

        timer = invTime;
    }

    void Start(){
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
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
        if(trans.position.y < -5 || trans.position.y > 10)
            Die();
    }
}
