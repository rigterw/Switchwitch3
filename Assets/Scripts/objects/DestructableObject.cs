using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : HealthManager
{
    public override void Die()
    {
        Destroy(this.gameObject);
        base.Die();
    }
}
