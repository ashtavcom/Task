using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReturnNameFunction : MonoBehaviour
{
    /*Function that returns name of gameobject with date appended to it.*/
    public string ReturnNameAndCurrentDate(GameObject go)
    {
        string str = go.name;
        string dt = DateTime.UtcNow.Date.ToShortDateString();
        str += "\t" + dt;
        return str;
    }
}
