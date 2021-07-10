using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float score;

    public Transform startingPoint;
    public float lerpSpeed = 5.0f;

    private SahilController sahilControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;

        sahilControllerScript = GameObject.Find("Sahil").GetComponent<SahilController>();

        sahilControllerScript.isStarted = false;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score = " + score);
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

    /**
     * 
     */
    IEnumerator PlayIntro()
    {
        Vector3 startPos = startingPoint.position;
        Vector3 endPos = sahilControllerScript.transform.position;

        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        sahilControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            sahilControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        sahilControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        sahilControllerScript.isStarted = true;
    }
}
