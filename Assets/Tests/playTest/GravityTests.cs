using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

using System.Collections;
using UnityEngine.SceneManagement;

public class GravityTests
{
    GameObject player;
    GravityController controller;
    static int[] parameterValues = new int[] { 1, 2, 3, 20 };

    [UnitySetUp]IEnumerator setup(){
        var op = SceneManager.LoadSceneAsync(2);
        while(!op.isDone)
            yield return null;
        player = GameObject.Find("Player");
        GameObject level = GameObject.Find("Level");
        controller = level.GetComponent<GravityController>();
    }

    /// <summary>
    /// function that changes the main mechanic of the game, which is changing gravity
    /// </summary>
    /// <param name="changeAmount">the amount of times the gravity gets changed</param>
 [UnityTest]public  IEnumerator changeGravityTest([ValueSource("parameterValues")] int changeAmount)
    {

        yield return new WaitForEndOfFrame();
        bool upSideDown = !(changeAmount % 2 == 0);
        for (int i = 0; i < changeAmount; i++)
        {
            controller.switchGravity();
            yield return new WaitForEndOfFrame();
        }


        float gravity = upSideDown ? -GravityController.gravity : GravityController.gravity;
        Assert.True(player.GetComponent<Rigidbody2D>().gravityScale == gravity);
        yield return new WaitForEndOfFrame();

    }

}
