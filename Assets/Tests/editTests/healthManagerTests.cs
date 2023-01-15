using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class healthmanagerTests
{

    // Test that checks if entity loses a life when hit.
    [Test]
    public void getHitTest()
    {

        GameObject entity = new GameObject();
        HealthManager Health = entity.AddComponent<HealthManager>();

        Health.GetHit();

        Assert.Less(Health.Health, HealthManager.MAXHEALTH);
    }

}
