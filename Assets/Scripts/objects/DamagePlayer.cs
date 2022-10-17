using UnityEngine;


/// <summary>
/// component that damages the player on collision
/// </summary>
public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other){
        HealthManager hm = other.gameObject.GetComponent<HealthManager>();
        if(hm != null)
            hm.GetHit();
    }
}
