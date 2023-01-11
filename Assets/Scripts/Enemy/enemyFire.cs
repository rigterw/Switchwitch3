using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int cooldownTime;
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        Fire();
    }

    private void Fire(){
        animator.SetTrigger("attack");

        //creates a bullet
        Projectile bullet = GameObject.Instantiate(bulletPrefab).GetComponent<Projectile>();
        bullet.Launch(getDirection(),transform);

        StartCoroutine(Cooldown());
    }

    
    /// <summary>
    /// function that calculates the velocty the bullet will have
    /// </summary>
    /// <returns>a vector3 of the velocity</returns>
    private Vector3 getDirection(){
        float vX = GetComponent<Enemy>().IsFacingRight ? 1 : -1;
        return new Vector3(vX, 0,0);
    }


    /// <summary>
    /// delays the next fire function for a few seconds
    /// </summary>
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(cooldownTime);

        Fire();
    }
}
