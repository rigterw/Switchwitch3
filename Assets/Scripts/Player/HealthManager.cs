using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public const int MAXHEALTH = 3;
    [SerializeField]
    int health = MAXHEALTH;
    int timer = 0;
    const int invTime = 150;

    SpriteRenderer sprite;


    /// <summary>
    /// function that kills the player
    /// </summary>
    public void Die(){
        health = 0;
        Debug.Log(transform.position);
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

    /// <summary>
    /// function that gives another healthpoint to the player
    /// </summary>
    public void Heal(){
        if(health == MAXHEALTH)
            return;
        health++;
        Debug.Log("life" + health);
        GameObject.Find("life" + health).SetActive(true);
    }


    /// <summary>
    /// function that heals the player a specific amount of lives
    /// </summary>
    /// <param name="amount">the amount of lives a player gets back</param>
    public void Heal(int amount){
        if(health + amount > MAXHEALTH)
            amount = MAXHEALTH - health;

        for (int i = 0; i < amount; i++){
            Heal();
        }
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
