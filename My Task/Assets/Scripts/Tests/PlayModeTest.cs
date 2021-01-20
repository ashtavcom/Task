using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModeTest
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
}
