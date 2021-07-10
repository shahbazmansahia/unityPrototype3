using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] obstaclePrefabs; // ensure the object at index 1 is the crate/pileable object
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
            int randoPrefab = Random.Range(0, obstaclePrefabs.Length);
            //int randoPrefab = 1; // for testing

            int numObj = 1;
            
            // checks if the object to be spawned is a crate or not; if it is, it sets spawns to a random number between 1 - 5
            if (randoPrefab == 1)
            {
                numObj = Random.Range(0, 2);
                float objHeight = obstaclePrefabs[randoPrefab].GetComponent<BoxCollider>().size.y; 
                for (int i = 0; i <= numObj; i++)
                {
                    Debug.Log(objHeight);
                    Debug.Log(numObj);

                    Vector3 tempSpawn = new Vector3(spawnPos.x, (spawnPos.y + (objHeight * i) + 0.1f), spawnPos.z);
                    Instantiate(obstaclePrefabs[randoPrefab], tempSpawn, obstaclePrefabs[randoPrefab].transform.rotation);
                }
            }

            else
            {
                Instantiate(obstaclePrefabs[randoPrefab], spawnPos, obstaclePrefabs[randoPrefab].transform.rotation);
            }
            
            // for spawning a pile of objects
            
            
        }
        
    }
}
