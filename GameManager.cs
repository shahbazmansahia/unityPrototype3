using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Increases the score as the player runs;
     * param: isActive - activates and deactivates the score tally depending on the value passed. Think of it as a start/stop for the counter
     *
    */
    public void incScore(bool isActive)
    {
        if (isActive)
        {
            score += Time.deltaTime;
        }
    }

    /**
     * Increases the score at a faster rate; to be used when the character dashes
     * param: isActive - activates and deactivates the score tally depending on the value passed. Think of it as a start/stop for the counter
     *
    */
    public void incScoreTwice(bool isActive)
    {
        if (isActive)
        {
            score += Time.deltaTime * 2.0f;
        }
    }

    /**
     * Stop all score counter functions. Intended to be used at gameOver
    */
    public void stopScore()
    {
        incScore(false);
        incScoreTwice(false);
    }
}
