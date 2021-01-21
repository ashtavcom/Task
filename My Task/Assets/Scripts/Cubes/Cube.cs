using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    bool stopMovement;
    bool isPaused;

    public Transform sphere1;
    public Transform sphere2;
    public Transform sphere3;

    public float speed;

    int positionIndex;
    Vector3 targetPosition;
    Vector3 lastPosition;
    readonly List<Transform> sphereList = new List<Transform>();

    // define the cube movement order here
    int[] pathOrder = {0, 1, 2, 1};

    // Start is called before the first frame update
    void Start()
    {
        stopMovement = false;
        isPaused = false;

        sphere1 = GameObject.Find("sphere1").transform;
        sphere2 = GameObject.Find("sphere2").transform;
        sphere3 = GameObject.Find("sphere3").transform;

        sphereList.Add(sphere1);
        sphereList.Add(sphere2);
        sphereList.Add(sphere3);

        positionIndex++;
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement && !isPaused)
        {
            CheckPosition();
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        targetPosition = sphereList[pathOrder[positionIndex]].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    void CheckPosition()
    {
        if (transform.position == targetPosition)
        {
            // update target position
            positionIndex++;
            if (positionIndex >= pathOrder.Length)
            {
                positionIndex = 0;
            }

            // if the cube is at point b then pause
            if (pathOrder[positionIndex] != 1)
            {
                StartCoroutine(EnableMovement());
            }
        }
    }

    IEnumerator EnableMovement()
    {
        stopMovement = true;
        yield return new WaitForSeconds(3);
        stopMovement = false;
    }

    public void OnPausePressed()
    {
        isPaused = !isPaused;
    }
}
