using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using player;

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
    //#############I tried to make a test to test the cooldown, however I found out that the bullet and fire state sadly have too many dependencies to make it work.


    // /// <summary>
    // /// unitytest that checks if the bullet despawns after a certain time
    // /// </summary>
    // [UnityTest] public IEnumerator BulletCooldownTest()
    // {
    //     GameObject player = new GameObject();
    //     StateMachine sm = player.AddComponent<StateMachine>();
    //     GameObject bullet = new GameObject("bullet");
    //     bullet.tag = "Projectile";
    //     bullet.AddComponent<SpriteRenderer>();
    //     bullet.AddComponent<Projectile>();
    //     player.AddComponent<Rigidbody2D>();
    //     player.AddComponent<SpriteRenderer>();
    //     player.AddComponent<Animator>().;
    //     int counter = 0;
    //     FireElement fireElement = new FireElement(sm, player.transform, bullet);
    //     for (int i = 0; i < fireElement.CooldownTime+1; i++){
        
    //         if(fireElement.UsePower())
    //          counter++;
    //         yield return new WaitForSeconds(1);
    //     }
    //     Assert.AreEqual(counter, 2);
    // }

}
