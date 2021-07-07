using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    private float repeatRate = 2.0f;
    private float startDelay = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Invokes the obstacle spawn function every <repeatRate> seconds after a delay of <startDelay>
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
