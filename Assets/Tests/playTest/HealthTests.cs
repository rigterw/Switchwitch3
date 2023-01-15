using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTests
{
    /// <summary>
/// test that checks if an entity can die
/// for this test a component of "destructableObject" is used instead of "HealthManager" which inherits from "healthmanager". This is because this class has an easy mesurable death (destroying itself).
/// </summary>
[UnityTest]public IEnumerator dieTest()
    {
        GameObject obj = new GameObject();

        DestructableObject objHealth = obj.AddComponent<DestructableObject>();
        for (int i = 0; i < DestructableObject.MAXHEALTH; i++)
            objHealth.GetHit();
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(obj == null);
    }    
}


