using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    private float repeatRate = 2.25f;
    private float startDelay = 2.0f;

    private SahilController sahilControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        sahilControllerScript = GameObject.Find("Sahil").GetComponent<SahilController>();
        // Invokes the obstacle spawn function every <repeatRate> seconds after a delay of <startDelay>
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        // will stop on game over. Doing this because the instructions demand this otherwise I actually like watching the obstacles pile up after the game is over! :(
        if (!sahilControllerScript.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
