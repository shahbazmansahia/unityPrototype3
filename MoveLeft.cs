using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float velocity = 30.0f;
    private SahilController sahilControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        sahilControllerScript = GameObject.Find("Sahil").GetComponent<SahilController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sahilControllerScript.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * velocity);
        }
        
    }
}
