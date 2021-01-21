using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public Action OnPauseClicked;
    public GameObject cubePrefab;
    bool isPaused;
    bool cubeSpawned;
    Transform sphere1;

    private void Start()
    {
        isPaused = false;
        cubeSpawned = false;
        sphere1 = GameObject.Find("sphere1").transform;
    }

    public void SpawnCube()
    {
        if(!isPaused)
        {
            GameObject cube = GameObject.Instantiate(cubePrefab, transform.position, transform.rotation);
            cube.transform.position = sphere1.position;
            OnPauseClicked += cube.GetComponent<Cube>().OnPausePressed;
            cubeSpawned = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("return"))
        {
            SpawnCube();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPauseClicked();
        }
    }

    public void OnCubeSpawn()
    {
        SpawnCube();
    }

    public void OnCubePause()
    {
        OnPauseClicked?.Invoke();
        if (cubeSpawned)
        {
            isPaused = !isPaused;
        }
    }
        
}
