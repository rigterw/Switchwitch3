using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletTests
{

/// <summary>
/// unitytest that checks if a bullet travels forward
/// </summary>
    [UnityTest] public IEnumerator BulletTravelTest()
    {
        var bullet = new GameObject();
        var bulletScript = bullet.AddComponent<Projectile>();

        bulletScript.Launch(new Vector3(1, 0, 0), bullet.transform);
        yield return new WaitForSeconds(5);

        Assert.IsTrue(bullet.transform.position.x > 1 && bullet.transform.position.y == 0);


    }
        /// <summary>
        /// unitytest that checks if the bullet despawns after a certain time
        /// </summary>
    [UnityTest] public IEnumerator BulletDespawnTest()
    {
        var bullet = new GameObject();
        var bulletScript = bullet.AddComponent<Projectile>();

        bulletScript.Launch(new Vector3(1, 0, 0), bullet.transform);
        yield return new WaitForSeconds(10);

        Assert.IsTrue(bullet == null);


    }

}
