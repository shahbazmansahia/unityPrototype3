using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahilController : MonoBehaviour
{
    private Rigidbody sahilRb;
    private float jumpForce = 10.0f;
    private float gravityForceMult = 1.5f; // set to 1.5 instead of 1 to make the object drop a bit faster
    private bool isGrounded = true;
    public bool isDashing;
    public bool isGameOver;
    public bool isStarted;

    private int numJumps;
    private float timestamp;
    private float jumpDelay = 0.25f;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource sahilAudio;
    public AudioClip jumpSoundFX;
    public AudioClip crashSoundFX;

    private Animator sahilAnim;

    private GameManager gameManager;
    
    public float gameVelocity = 30.0f;

    public float walkinInit = -5.0f;
    public float walkinEnd = 0.0f;
    private float timeElapsed;
    public float lerpDuration = 5.0f;
    private float valueToLerp;

    // Start is called before the first frame update
    void Start()
    {
        sahilRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityForceMult;
        jumpForce = sahilRb.mass * 11.6777f; // to set jump force propotionally to the object's mass 

        sahilAudio = GetComponent<AudioSource>();
        sahilAnim = GetComponent<Animator>();
        isGameOver = false;
        isDashing = false;
        isStarted = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.incScore(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isStarted: " + isStarted);
        if (isStarted)
        {
            if (!isGameOver)
            {
                gameManager.incScore(Time.deltaTime, 1);
            }

            if ((Input.GetKeyDown(KeyCode.Space)) && (numJumps > 0) && (!isGameOver) && (Time.time >= timestamp))
            {
                sahilRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                numJumps--;
                timestamp = Time.time + jumpDelay;
                isGrounded = false;
                sahilAnim.SetTrigger("Jump_trig");
                sahilAudio.PlayOneShot(jumpSoundFX, 1.0f);
                dirtParticle.Stop();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && (!isGameOver))
            {
                //Debug.Log("Sahil anim speed:" + sahilAnim.speed);
                sahilAnim.speed = 2;
                isDashing = true;
                gameManager.incScore(Time.deltaTime, 2);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && (!isGameOver))
            {
                //Debug.Log("Sahil dash anim speed:" + sahilAnim.speed);
                sahilAnim.speed = 1;
                isDashing = false;
                gameManager.incScore(Time.deltaTime, 1);
            }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && (!isGameOver))
        {
            isGrounded = true;
            dirtParticle.Play();
            numJumps = 2;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        
        Debug.Log("Game 0v3r!");
        isGameOver = true;
        gameManager.stopScore();
        dirtParticle.Stop();
        explosionParticle.Play();
        sahilAudio.PlayOneShot(crashSoundFX, 1.0f);
        sahilAnim.SetBool("Death_b", true);
        sahilAnim.SetInteger("DeathType_int", 2);
        
    }
}
