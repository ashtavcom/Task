using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReturnNameFunction : MonoBehaviour
{

    public void ReturnNameAndCurrentTime(GameObject go)
    {
        string s = go.name;
        string dt = DateTime.UtcNow.Date.ToShortDateString();
        Debug.Log("Name: " + s + "\t" + "Current UTC Date: " + dt);
    }
}
