using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class healthmanagerTests
{
    static int[] parameterValues = new int[] { 1, 2, 3, 20 };
    // Test that checks if entity loses a life when hit.
    [Test]
    public void getHitTest([ValueSource("parameterValues")] int hitAmounts)
    {

        GameObject entity = new GameObject();
        HealthManager Health = entity.AddComponent<HealthManager>();
        for (int i = 0; i < hitAmounts; i++)
            Health.GetHit();

        Assert.Less(Health.Health, HealthManager.MAXHEALTH);
    }

    /// <summary>
    /// test that checks if an entity can get healing but can't be overhealed
    /// </summary>
    [Test]public void healTest([ValueSource("parameterValues")] int healAmount){

        GameObject entity = new GameObject();
        HealthManager Health = entity.AddComponent<HealthManager>();
        int startHealth = 1;


        //first damage the entity so it can be healed
        for (int i = startHealth; i < HealthManager.MAXHEALTH; i++)
            Health.GetHit();
        
        //updates the starthealth for the case the gethit doesn't work properly
        startHealth = Health.Health;

        Health.Heal(healAmount);

        Assert.IsTrue(Health.Health != startHealth && Health.Health <= HealthManager.MAXHEALTH);

    }

}
