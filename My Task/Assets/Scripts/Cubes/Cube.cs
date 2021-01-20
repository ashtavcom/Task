using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    bool repeatSequence;
    bool stopMovement;
    bool isPaused;

    string previousPoint;

    Vector3 pointA = new Vector3(-2, 0, -6);
    Vector3 pointB = new Vector3(2, 0, -6);
    Vector3 pointC = new Vector3(0, 0, 0);

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        previousPoint = "a";
        repeatSequence = false;
        stopMovement = false;
        targetPosition = pointB;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement && !isPaused)
        {
            MoveToTarget();
            CheckPosition();
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 3);
    }

    void CheckPosition()
    {
        if (transform.position == pointB)
        {
            if(previousPoint == "a")
            {
                targetPosition = pointC;
            }
            else if(previousPoint == "c")
            {
                targetPosition = pointA;
            }
            stopMovement = true;
            StartCoroutine(EnableMovement());
        }
        else if (transform.position == pointC)
        {
            targetPosition = pointB;
            previousPoint = "c";
        }
        else if(transform.position == pointA)
        {
            targetPosition = pointB;
            previousPoint = "a";
        }
    }

    IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(3);
        stopMovement = false;
    }

    public void OnPausePressed()
    {
        isPaused = !isPaused;
    }
}
