using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = 0.1f;
    }

    private void OnMouseDrag()
    {
        transform.position += new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0);
    }
}
