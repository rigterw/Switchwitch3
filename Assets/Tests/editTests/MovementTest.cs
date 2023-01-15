using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void MovementTestSimplePasses()
    {
        Debug.Log("test");
        Assert.AreEqual(3, 3, "aa");
    }
}
