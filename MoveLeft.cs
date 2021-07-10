using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float velocity = 30.0f;
    public float dashSpeed = 1.5f;
    private SahilController sahilControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        sahilControllerScript = GameObject.Find("Sahil").GetComponent<SahilController>();
        velocity = sahilControllerScript.gameVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!sahilControllerScript.isGameOver)
        {
            if (sahilControllerScript.isDashing)
            {
                transform.Translate(Vector3.left * Time.deltaTime * velocity * dashSpeed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * velocity);
            }
        }

        
    }
    
}
