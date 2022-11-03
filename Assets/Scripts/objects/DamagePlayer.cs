using UnityEngine;


/// <summary>
/// component that damages the player on collision
/// </summary>
public class DamagePlayer : MonoBehaviour
{
    [SerializeField]AudioSource damageSound;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        Damage(other);
    }

    protected virtual void Damage(Collider2D other){
        HealthManager hm = other.gameObject.GetComponent<HealthManager>();
        if(hm == null)
            return;
        
        hm.GetHit();

        damageSound.Play();
    }
}
