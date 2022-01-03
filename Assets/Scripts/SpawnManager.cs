using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefab = new GameObject[5];
    private Vector3 spawnPos = new Vector3(-4, 1, 0);
    private float startDelay = 5;
    private float repeatRate = 3;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        index = Random.Range(0, 5);
        Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
    }

}

