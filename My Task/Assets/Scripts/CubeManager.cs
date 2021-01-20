using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public Action OnPauseClicked;
    public GameObject cubePrefab;

    public Button spawnBtn;
    public Button pauseBtn;

    // Start is called before the first frame update
    void Start()
    {
        spawnBtn.onClick.AddListener(OnCubeSpawn);
        pauseBtn.onClick.AddListener(OnCubePause);
    }

    public void SpawnCube()
    {
        GameObject cube = GameObject.Instantiate(cubePrefab, transform.position, transform.rotation);
        cube.transform.position = new Vector3(-2, 0, -6);
        OnPauseClicked += cube.GetComponent<Cube>().OnPausePressed;
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

    void OnCubeSpawn()
    {
        SpawnCube();
    }

    void OnCubePause()
    {
        OnPauseClicked();
    }
        
}
