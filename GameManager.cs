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
        Debug.Log("Score = " + score);
    }

    /**
     * Increases the score as the player runs;
     * param: isActive - activates and deactivates the score tally depending on the value passed. Think of it as a start/stop for the counter
     *
    */
    public void incScore(float value, int multiplier)
    {
            score += value * multiplier * 100;
    }

    /**
     * Increases the score at a faster rate; to be used when the character dashes
     * param: isActive - activates and deactivates the score tally depending on the value passed. Think of it as a start/stop for the counter
     *
    */

    /**
     * Stop all score counter functions. Intended to be used at gameOver
    */
    public void stopScore()
    {
        incScore(0.0f, 0);
    }
}
