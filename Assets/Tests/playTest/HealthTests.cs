using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

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
    /// <summary>
    /// test that checks if the UI hearts stay up to date 
    /// </summary>
    [UnityTest] public IEnumerator UITest(){

        var op = SceneManager.LoadSceneAsync(2);
        while(!op.isDone)
            yield return null;
        GameObject player = GameObject.Find("Player");
        GameObject playerUI = GameObject.Find("LevelUI");

        Transform livesUI = playerUI.transform.Find("LivesUI");
        int startAmount = CountActiveChildren(livesUI);

        player.GetComponent<HealthManager>().GetHit();
        yield return new WaitForEndOfFrame();
        Assert.Less(CountActiveChildren(livesUI), startAmount);
    }

    /// <summary>
    /// function that counts all active childs of a parent
    /// </summary>
    /// <param name="parent">the object that the childs need to be checked from</param>
    /// <returns>the amount of children that are active</returns>
    private int CountActiveChildren(Transform parent){
        int counter = 0;
        foreach(Transform child in parent){
            if(child.gameObject.activeInHierarchy){
                counter++;
            }
        }

        return counter;
    }

}


