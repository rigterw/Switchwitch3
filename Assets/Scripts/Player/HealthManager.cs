using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int health = 3;
    bool invincible = false;
    int timer = 200;
    int invTime = 500;


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

        health--;

        if(health <= 0)
            Die();

        timer = invTime;
    }

    void FixedUpdate(){
        if(timer > 0){
            timer--;
            Debug.Log(timer);
        }
    }
    
    void Flash(){
        
    }
}
