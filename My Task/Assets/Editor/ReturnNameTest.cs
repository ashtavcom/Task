using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ReturnNameTest 
{

    public GameObject go;
    [SetUp]
    public void Setup()
    {
        go = GameObject.Instantiate(new GameObject());
        go.name = "Test Name";
        go.AddComponent<ReturnNameFunction>();
    }

    [Test]
    public void ReturnNameAndCurrentTimeTest()
    {
        var rnf = go.GetComponent<ReturnNameFunction>();

        rnf.ReturnNameAndCurrentTime(go);        
    }
}
