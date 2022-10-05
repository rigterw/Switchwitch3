using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    bool invincible = false;
    int health = 3;

    public void Die(){
        health = 0;
        StateMachine sm = GetComponent<StateMachine>();
    }
    public int Health {
        get  => health;
    }


    
}
