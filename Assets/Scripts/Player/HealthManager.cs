using UnityEngine;
public class HealthManager : MonoBehaviour
{
    public const int MAXHEALTH = 3;
    [SerializeField] protected int health;

    /// <summary>
    /// function that kills the player
    /// </summary>
    public virtual void Die(){
        health = 0;        
    }
    public int Health {
        get  => health;
    }


    /// <summary>
    /// function that makes the player lose a life
    /// </summary>
    public virtual void GetHit(){
        health--;
        if(health <= 0)
            Die();
    }

    /// <summary>
    /// function that gives another healthpoint to the player
    /// </summary>
    public virtual void Heal(){
        if(health == MAXHEALTH)
            return;
        health++;
    }

    void Start(){
        if(health <0){
            Debug.LogError("health is lower than 1");
        }
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

   
}
